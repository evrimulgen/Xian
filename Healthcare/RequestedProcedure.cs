using System;
using System.Collections;
using System.Text;

using Iesi.Collections;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Workflow;
using System.Collections.Generic;


namespace ClearCanvas.Healthcare {


    /// <summary>
    /// RequestedProcedure entity
    /// </summary>
	public partial class RequestedProcedure : Entity
	{
        public RequestedProcedure(Order order, RequestedProcedureType type, string index)
        {
            _order = order;
            _order.RequestedProcedures.Add(this);

            _type = type;
            _index = index;

            _procedureSteps = new HybridSet();
        }
	
        #region Public Properties

        /// <summary>
        /// Gets the check-in procedure step.
        /// </summary>
        public CheckInProcedureStep CheckInProcedureStep
        {
            get
            {
                ProcedureStep step = CollectionUtils.SelectFirst<ProcedureStep>(this.ProcedureSteps,
                    delegate(ProcedureStep ps)
                    {
                        return ps.Is<CheckInProcedureStep>();
                    });

                return step == null ? null : step.Downcast<CheckInProcedureStep>();
            }
        }

        /// <summary>
        /// Gets the modality procedure steps.
        /// </summary>
        public List<ModalityProcedureStep> ModalityProcedureSteps
        {
            get
            {
                return CollectionUtils.Map<ProcedureStep, ModalityProcedureStep>(
                    CollectionUtils.Select<ProcedureStep>(this.ProcedureSteps,
                        delegate(ProcedureStep ps)
                        {
                            return ps.Is<ModalityProcedureStep>();
                        }), delegate(ProcedureStep ps) { return ps.As<ModalityProcedureStep>(); });
            }
        }

        /// <summary>
        /// Gets a value indicating whether this procedure is in a terminal state.
        /// </summary>
        public virtual bool IsTerminated
        {
            get
            {
                return _status == RequestedProcedureStatus.CM || _status == RequestedProcedureStatus.CA || _status == RequestedProcedureStatus.DC;
            }
        }

        #endregion

        #region Public Operations

        /// <summary>
        /// Adds a procedure step.  Use this method rather than adding directly to the <see cref="ProcedureSteps"/>
        /// collection.
        /// </summary>
        /// <param name="step"></param>
        public virtual void AddProcedureStep(ProcedureStep step)
        {
            if (step.RequestedProcedure != null)
            {
                step.RequestedProcedure.ProcedureSteps.Remove(step);
            }

            step.RequestedProcedure = this;
            this.ProcedureSteps.Add(step);
        }

        /// <summary>
        /// Discontinue this procedure and any procedure steps in the scheduled state.
        /// </summary>
        public virtual void Discontinue()
        {
            if (_status != RequestedProcedureStatus.IP)
                throw new WorkflowException("Only procedures in the IP status can be discontinued");

            // update the status prior to cancelling the procedure steps
            // (otherwise cancelling the steps will cause them to try and update the procedure status)
            SetStatus(RequestedProcedureStatus.DC);
            
            // discontinue any procedure steps in the scheduled status
            foreach (ProcedureStep ps in _procedureSteps)
            {
                if (ps.State == ActivityStatus.SC)
                    ps.Discontinue();
            }
        }

        /// <summary>
        /// Cancel this procedure and all procedure steps.
        /// </summary>
        public virtual void Cancel()
        {
            if (_status != RequestedProcedureStatus.SC)
                throw new WorkflowException("Only procedures in the SC status can be cancelled");

            // update the status prior to cancelling the procedure steps
            // (otherwise cancelling the steps will cause them to try and update the procedure status)
            SetStatus(RequestedProcedureStatus.CA);

            // discontinue all procedure steps (they should all be in the SC status)
            foreach (ProcedureStep ps in _procedureSteps)
            {
                ps.Discontinue();
            }
        }

        #endregion

        #region Object overrides

        public override bool Equals(object that)
		{
			// TODO: implement a test for business-key equality
			return base.Equals(that);
		}
		
		public override int GetHashCode()
		{
			// TODO: implement a hash-code based on the business-key used in the Equals() method
			return base.GetHashCode();
		}
		
		#endregion

        #region Helper methods

        /// <summary>
        /// Called by a child procedure step to complete this procedure.
        /// </summary>
        internal void Complete()
        {
            if (_status != RequestedProcedureStatus.IP)
                throw new WorkflowException("Only procedures in the IP status can be completed");

            SetStatus(RequestedProcedureStatus.CM);
        }

        /// <summary>
        /// Called by child procedure steps to tell this procedure to update its scheduling information.
        /// </summary>
        internal void UpdateScheduling()
        {
            // compute the earliest procedure step scheduled start time
            _scheduledStartTime = CollectionUtils.Min<DateTime?>(
                CollectionUtils.Select<DateTime?>(
                    CollectionUtils.Map<ProcedureStep, DateTime?>(this.ProcedureSteps,
                        delegate(ProcedureStep step) { return step.Scheduling.StartTime; }),
                            delegate(DateTime? startTime) { return startTime != null; }), null);

            _order.UpdateScheduling();
        }

        /// <summary>
        /// Called by a child procedure step to tell the procedure to update its status.  Only
        /// certain status updates can be inferred deterministically from child statuses.  If no
        /// status can be inferred, the status does not change.
        /// </summary>
        internal void UpdateStatus()
        {
            // check if the procedure should be auto-discontinued
            if (_status == RequestedProcedureStatus.SC || _status == RequestedProcedureStatus.IP)
            {
                // if all steps are discontinued, this procedure is automatically discontinued
                if (CollectionUtils.TrueForAll<ProcedureStep>(_procedureSteps,
                    delegate(ProcedureStep step) { return step.State == ActivityStatus.DC; }))
                {
                    SetStatus(RequestedProcedureStatus.DC);
                }
            }

            // check if the procedure should be auto-started
            if (_status == RequestedProcedureStatus.SC)
            {
                // the condition for auto-starting the procedure is that it has a procedure step that has
                // moved out of the scheduled status but not into the discontinued status
                bool anyStepStartedNotDiscontinued = CollectionUtils.Contains<ProcedureStep>(_procedureSteps,
                    delegate(ProcedureStep step)
                    {
                        return !step.IsInitial && step.State != ActivityStatus.DC;
                    });

                if (anyStepStartedNotDiscontinued)
                {
                    SetStatus(RequestedProcedureStatus.IP);
                }
            }
        }

        /// <summary>
        /// Helper method to change the status and also notify the parent order to change its status
        /// if necessary.
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(RequestedProcedureStatus status)
        {
            _status = status;

            _order.UpdateStatus();
        }

        /// <summary>
        /// This method is called from the constructor.  Use this method to implement any custom
        /// object initialization.
        /// </summary>
        private void CustomInitialize()
        {
        }

        #endregion
    }
}
