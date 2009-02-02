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

namespace ClearCanvas.ImageServer.Model
{
    using System;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class Device: ServerEntity
    {
        #region Constructors
        public Device():base("Device")
        {}
        #endregion

        #region Private Members
        private System.String _aeTitle;
        private System.Boolean _allowAutoRoute;
        private System.Boolean _allowQuery;
        private System.Boolean _allowRetrieve;
        private System.Boolean _allowStorage;
        private System.String _description;
        private System.Boolean _dhcp;
        private System.Boolean _enabled;
        private System.String _ipAddress;
        private System.Int32 _port;
        private ClearCanvas.ImageServer.Enterprise.ServerEntityKey _serverPartitionKey;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="AeTitle")]
        public System.String AeTitle
        {
        get { return _aeTitle; }
        set { _aeTitle = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="AllowAutoRoute")]
        public System.Boolean AllowAutoRoute
        {
        get { return _allowAutoRoute; }
        set { _allowAutoRoute = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="AllowQuery")]
        public System.Boolean AllowQuery
        {
        get { return _allowQuery; }
        set { _allowQuery = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="AllowRetrieve")]
        public System.Boolean AllowRetrieve
        {
        get { return _allowRetrieve; }
        set { _allowRetrieve = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="AllowStorage")]
        public System.Boolean AllowStorage
        {
        get { return _allowStorage; }
        set { _allowStorage = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="Description")]
        public System.String Description
        {
        get { return _description; }
        set { _description = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="Dhcp")]
        public System.Boolean Dhcp
        {
        get { return _dhcp; }
        set { _dhcp = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="Enabled")]
        public System.Boolean Enabled
        {
        get { return _enabled; }
        set { _enabled = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="IpAddress")]
        public System.String IpAddress
        {
        get { return _ipAddress; }
        set { _ipAddress = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="Port")]
        public System.Int32 Port
        {
        get { return _port; }
        set { _port = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="Device", ColumnName="ServerPartitionGUID")]
        public ClearCanvas.ImageServer.Enterprise.ServerEntityKey ServerPartitionKey
        {
        get { return _serverPartitionKey; }
        set { _serverPartitionKey = value; }
        }
        #endregion

        #region Static Methods
        static public Device Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public Device Load(IReadContext read, ServerEntityKey key)
        {
            IDeviceEntityBroker broker = read.GetBroker<IDeviceEntityBroker>();
            Device theObject = broker.Load(key);
            return theObject;
        }
        #endregion
    }
}
