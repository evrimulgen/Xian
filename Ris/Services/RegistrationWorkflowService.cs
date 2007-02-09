using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Healthcare;
using ClearCanvas.Enterprise;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Common;
using Iesi.Collections;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Healthcare.Workflow.Registration;

namespace ClearCanvas.Ris.Services
{
    [ExtensionOf(typeof(ClearCanvas.Enterprise.ServiceLayerExtensionPoint))]
    public class RegistrationWorkflowService : WorkflowServiceBase, IRegistrationWorkflowService
    {
        [ReadOperation]
        public IList<RegistrationWorklistQueryResult> GetWorklist(ModalityProcedureStepSearchCriteria criteria)
        {
            IRegistrationWorklistBroker broker = CurrentContext.GetBroker<IRegistrationWorklistBroker>();
            return broker.GetWorklist(criteria, "UHN");
        }

        [ReadOperation]
        public RegistrationWorklistQueryResult GetWorklistItem(EntityRef<ModalityProcedureStep> mpsRef)
        {
            IRegistrationWorklistBroker broker = CurrentContext.GetBroker<IRegistrationWorklistBroker>();
            return broker.GetWorklistItem(mpsRef, "UHN");
        }

        [ReadOperation]
        public ModalityProcedureStep LoadWorklistItemPreview(RegistrationWorklistQueryResult item)
        {
            IModalityProcedureStepBroker spsBroker = this.CurrentContext.GetBroker<IModalityProcedureStepBroker>();
            IRequestedProcedureBroker rpBroker = this.CurrentContext.GetBroker<IRequestedProcedureBroker>();
            IOrderBroker orderBroker = this.CurrentContext.GetBroker<IOrderBroker>();
            IPatientBroker patientBroker = this.CurrentContext.GetBroker<IPatientBroker>();

            ModalityProcedureStep sps = spsBroker.Load(item.ProcedureStep);

            // force a whole bunch of relationships to load... this could be optimized by using fetch joins
            //spsBroker.LoadRequestedProcedureForModalityProcedureStep(sps);
            //rpBroker.LoadOrderForRequestedProcedure(sps.RequestedProcedure);
            orderBroker.LoadOrderingFacilityForOrder(sps.RequestedProcedure.Order);

            // ensure that these associations are loaded
            orderBroker.LoadDiagnosticServiceForOrder(sps.RequestedProcedure.Order);
            spsBroker.LoadTypeForModalityProcedureStep(sps);
            rpBroker.LoadTypeForRequestedProcedure(sps.RequestedProcedure);

            
            patientBroker.LoadProfilesForPatient( sps.RequestedProcedure.Order.Patient );
            return sps;
        }

        [UpdateOperation]
        public void ExecuteOperation(EntityRef<ModalityProcedureStep> stepRef, string operationClassName)
        {
            ExecuteOperation(LoadStep(stepRef), 
                new ClearCanvas.Healthcare.Workflow.Registration.WorkflowOperationExtensionPoint(), operationClassName);
        }

        [ReadOperation]
        public IDictionary<string, bool> GetOperationEnablement(EntityRef<ModalityProcedureStep> stepRef)
        {
            return GetOperationEnablement(LoadStep(stepRef),
                new ClearCanvas.Healthcare.Workflow.Registration.WorkflowOperationExtensionPoint());
        }

        [ReadOperation]
        public ModalityProcedureStep LoadStep(EntityRef<ModalityProcedureStep> stepRef)
        {
            IModalityProcedureStepBroker broker = this.CurrentContext.GetBroker<IModalityProcedureStepBroker>();
            return broker.Load(stepRef, EntityLoadFlags.CheckVersion);
        }
    }
}
