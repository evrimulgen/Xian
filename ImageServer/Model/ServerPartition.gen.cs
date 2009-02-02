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
    public partial class ServerPartition: ServerEntity
    {
        #region Constructors
        public ServerPartition():base("ServerPartition")
        {}
        #endregion

        #region Private Members
        private System.Boolean _acceptAnyDevice;
        private System.String _aeTitle;
        private System.Boolean _auditDeleteStudy;
        private System.Boolean _autoInsertDevice;
        private System.Int32 _defaultRemotePort;
        private System.String _description;
        private DuplicateSopPolicyEnum _duplicateSopPolicyEnum;
        private System.Boolean _enabled;
        private System.Boolean _matchAccessionNumber;
        private System.Boolean _matchIssuerOfPatientId;
        private System.Boolean _matchPatientId;
        private System.Boolean _matchPatientsBirthDate;
        private System.Boolean _matchPatientsName;
        private System.Boolean _matchPatientsSex;
        private System.String _partitionFolder;
        private System.Int32 _port;
        private System.Int32 _studyCount;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="AcceptAnyDevice")]
        public System.Boolean AcceptAnyDevice
        {
        get { return _acceptAnyDevice; }
        set { _acceptAnyDevice = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="AeTitle")]
        public System.String AeTitle
        {
        get { return _aeTitle; }
        set { _aeTitle = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="AuditDeleteStudy")]
        public System.Boolean AuditDeleteStudy
        {
        get { return _auditDeleteStudy; }
        set { _auditDeleteStudy = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="AutoInsertDevice")]
        public System.Boolean AutoInsertDevice
        {
        get { return _autoInsertDevice; }
        set { _autoInsertDevice = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="DefaultRemotePort")]
        public System.Int32 DefaultRemotePort
        {
        get { return _defaultRemotePort; }
        set { _defaultRemotePort = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="Description")]
        public System.String Description
        {
        get { return _description; }
        set { _description = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="DuplicateSopPolicyEnum")]
        public DuplicateSopPolicyEnum DuplicateSopPolicyEnum
        {
        get { return _duplicateSopPolicyEnum; }
        set { _duplicateSopPolicyEnum = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="Enabled")]
        public System.Boolean Enabled
        {
        get { return _enabled; }
        set { _enabled = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchAccessionNumber")]
        public System.Boolean MatchAccessionNumber
        {
        get { return _matchAccessionNumber; }
        set { _matchAccessionNumber = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchIssuerOfPatientId")]
        public System.Boolean MatchIssuerOfPatientId
        {
        get { return _matchIssuerOfPatientId; }
        set { _matchIssuerOfPatientId = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchPatientId")]
        public System.Boolean MatchPatientId
        {
        get { return _matchPatientId; }
        set { _matchPatientId = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchPatientsBirthDate")]
        public System.Boolean MatchPatientsBirthDate
        {
        get { return _matchPatientsBirthDate; }
        set { _matchPatientsBirthDate = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchPatientsName")]
        public System.Boolean MatchPatientsName
        {
        get { return _matchPatientsName; }
        set { _matchPatientsName = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="MatchPatientsSex")]
        public System.Boolean MatchPatientsSex
        {
        get { return _matchPatientsSex; }
        set { _matchPatientsSex = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="PartitionFolder")]
        public System.String PartitionFolder
        {
        get { return _partitionFolder; }
        set { _partitionFolder = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="Port")]
        public System.Int32 Port
        {
        get { return _port; }
        set { _port = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerPartition", ColumnName="StudyCount")]
        public System.Int32 StudyCount
        {
        get { return _studyCount; }
        set { _studyCount = value; }
        }
        #endregion

        #region Static Methods
        static public ServerPartition Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public ServerPartition Load(IReadContext read, ServerEntityKey key)
        {
            IServerPartitionEntityBroker broker = read.GetBroker<IServerPartitionEntityBroker>();
            ServerPartition theObject = broker.Load(key);
            return theObject;
        }
        #endregion
    }
}
