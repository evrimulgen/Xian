using System;
using System.Runtime.Serialization;

using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.Admin.HL7Admin
{
    [DataContract]
    public class ProcessHL7QueueItemRequest : DataContractBase
    {
        public ProcessHL7QueueItemRequest(EntityRef queueItemRef)
        {
            this.QueueItemRef = queueItemRef;
        }

        [DataMember]
        public EntityRef QueueItemRef;
    }
}
