#region License

// Copyright (c) 2006-2009, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

// This file is auto-generated by the ClearCanvas.Model.SqlServer2005.CodeGenerator project.

namespace ClearCanvas.ImageServer.Model.EntityBrokers
{
    using ClearCanvas.ImageServer.Enterprise;

   public class ServiceLockUpdateColumns : EntityUpdateColumns
   {
       public ServiceLockUpdateColumns()
       : base("ServiceLock")
       {}
        public System.Boolean Enabled
        {
            set { SubParameters["Enabled"] = new EntityUpdateColumn<System.Boolean>("Enabled", value); }
        }
        public ClearCanvas.ImageServer.Enterprise.ServerEntityKey FilesystemKey
        {
            set { SubParameters["FilesystemKey"] = new EntityUpdateColumn<ClearCanvas.ImageServer.Enterprise.ServerEntityKey>("FilesystemKey", value); }
        }
        public System.Boolean Lock
        {
            set { SubParameters["Lock"] = new EntityUpdateColumn<System.Boolean>("Lock", value); }
        }
        public System.String ProcessorId
        {
            set { SubParameters["ProcessorId"] = new EntityUpdateColumn<System.String>("ProcessorId", value); }
        }
        public System.DateTime ScheduledTime
        {
            set { SubParameters["ScheduledTime"] = new EntityUpdateColumn<System.DateTime>("ScheduledTime", value); }
        }
        public ServiceLockTypeEnum ServiceLockTypeEnum
        {
            set { SubParameters["ServiceLockTypeEnum"] = new EntityUpdateColumn<ServiceLockTypeEnum>("ServiceLockTypeEnum", value); }
        }
        public System.Xml.XmlDocument State
        {
            set { SubParameters["State"] = new EntityUpdateColumn<System.Xml.XmlDocument>("State", value); }
        }
    }
}
