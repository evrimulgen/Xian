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
    using System.Xml;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class ArchiveQueue: ServerEntity
    {
        #region Constructors
        public ArchiveQueue():base("ArchiveQueue")
        {}
        public ArchiveQueue(
             ArchiveQueueStatusEnum _archiveQueueStatusEnum_
            ,System.String _failureDescription_
            ,ClearCanvas.ImageServer.Enterprise.ServerEntityKey _partitionArchiveKey_
            ,System.String _processorId_
            ,System.DateTime _scheduledTime_
            ,ClearCanvas.ImageServer.Enterprise.ServerEntityKey _studyStorageKey_
            ):base("ArchiveQueue")
        {
            _archiveQueueStatusEnum = _archiveQueueStatusEnum_;
            _failureDescription = _failureDescription_;
            _partitionArchiveKey = _partitionArchiveKey_;
            _processorId = _processorId_;
            _scheduledTime = _scheduledTime_;
            _studyStorageKey = _studyStorageKey_;
        }
        #endregion

        #region Private Members
        private ArchiveQueueStatusEnum _archiveQueueStatusEnum;
        private String _failureDescription;
        private ServerEntityKey _partitionArchiveKey;
        private String _processorId;
        private DateTime _scheduledTime;
        private ServerEntityKey _studyStorageKey;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="ArchiveQueueStatusEnum")]
        public ArchiveQueueStatusEnum ArchiveQueueStatusEnum
        {
        get { return _archiveQueueStatusEnum; }
        set { _archiveQueueStatusEnum = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="FailureDescription")]
        public String FailureDescription
        {
        get { return _failureDescription; }
        set { _failureDescription = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="PartitionArchiveGUID")]
        public ServerEntityKey PartitionArchiveKey
        {
        get { return _partitionArchiveKey; }
        set { _partitionArchiveKey = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="ProcessorId")]
        public String ProcessorId
        {
        get { return _processorId; }
        set { _processorId = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="ScheduledTime")]
        public DateTime ScheduledTime
        {
        get { return _scheduledTime; }
        set { _scheduledTime = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ArchiveQueue", ColumnName="StudyStorageGUID")]
        public ServerEntityKey StudyStorageKey
        {
        get { return _studyStorageKey; }
        set { _studyStorageKey = value; }
        }
        #endregion

        #region Static Methods
        static public ArchiveQueue Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public ArchiveQueue Load(IPersistenceContext read, ServerEntityKey key)
        {
            IArchiveQueueEntityBroker broker = read.GetBroker<IArchiveQueueEntityBroker>();
            ArchiveQueue theObject = broker.Load(key);
            return theObject;
        }
        static public ArchiveQueue Insert(ArchiveQueue entity)
        {
            using (IUpdateContext update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                ArchiveQueue newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public ArchiveQueue Insert(IUpdateContext update, ArchiveQueue entity)
        {
            IArchiveQueueEntityBroker broker = update.GetBroker<IArchiveQueueEntityBroker>();
            ArchiveQueueUpdateColumns updateColumns = new ArchiveQueueUpdateColumns();
            updateColumns.ArchiveQueueStatusEnum = entity.ArchiveQueueStatusEnum;
            updateColumns.FailureDescription = entity.FailureDescription;
            updateColumns.PartitionArchiveKey = entity.PartitionArchiveKey;
            updateColumns.ProcessorId = entity.ProcessorId;
            updateColumns.ScheduledTime = entity.ScheduledTime;
            updateColumns.StudyStorageKey = entity.StudyStorageKey;
            ArchiveQueue newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}
