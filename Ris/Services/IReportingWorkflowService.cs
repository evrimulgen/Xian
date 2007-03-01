using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Services
{
    public interface IReportingWorkflowService : IHealthcareServiceLayer
    {
        IList<ReportingWorklistQueryResult> GetWorklist(Type stepClass, ReportingProcedureStepSearchCriteria criteria);

        void ScheduleInterpretation(EntityRef procedure);

        void ClaimInterpretation(EntityRef step);
        void StartInterpretation(EntityRef step);
        void CompleteInterpretationForTranscription(EntityRef step);
        void CompleteInterpretationForVerification(EntityRef step);
        void CompleteInterpretationAndVerify(EntityRef step);

        void CancelPendingTranscription(EntityRef step);

        void StartVerification(EntityRef step);
        void CompleteVerification(EntityRef step);
    }
}
