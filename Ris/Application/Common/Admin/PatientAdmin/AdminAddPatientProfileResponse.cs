using System;
using System.Runtime.Serialization;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow;

namespace ClearCanvas.Ris.Application.Common.Admin.PatientAdmin
{
    [DataContract]
    public class AdminAddPatientProfileResponse : DataContractBase
    {
        public AdminAddPatientProfileResponse(RegistrationWorklistItem worklistItem)
        {
            this.WorklistItem = worklistItem;
        }

        [DataMember]
        public RegistrationWorklistItem WorklistItem;
    }
}
