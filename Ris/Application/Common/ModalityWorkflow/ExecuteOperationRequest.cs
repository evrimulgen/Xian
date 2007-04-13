using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.ModalityWorkflow
{
    [DataContract]
    public class ExecuteOperationRequest : DataContractBase
    {
        [DataMember]
        public EntityRef ProcedureStepRef;

        [DataMember]
        public string OperationClassName;
    }
}
