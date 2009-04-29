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
    using ClearCanvas.Dicom;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class ServerSopClass: ServerEntity
    {
        #region Constructors
        public ServerSopClass():base("ServerSopClass")
        {}
        public ServerSopClass(
             System.String _description_
            ,System.Boolean _nonImage_
            ,System.String _sopClassUid_
            ):base("ServerSopClass")
        {
            _description = _description_;
            _nonImage = _nonImage_;
            _sopClassUid = _sopClassUid_;
        }
        #endregion

        #region Private Members
        private String _description;
        private Boolean _nonImage;
        private String _sopClassUid;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="ServerSopClass", ColumnName="Description")]
        public String Description
        {
        get { return _description; }
        set { _description = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="ServerSopClass", ColumnName="NonImage")]
        public Boolean NonImage
        {
        get { return _nonImage; }
        set { _nonImage = value; }
        }
        [DicomField(DicomTags.SopClassUid, DefaultValue = DicomFieldDefault.Null)]
        [EntityFieldDatabaseMappingAttribute(TableName="ServerSopClass", ColumnName="SopClassUid")]
        public String SopClassUid
        {
        get { return _sopClassUid; }
        set { _sopClassUid = value; }
        }
        #endregion

        #region Static Methods
        static public ServerSopClass Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public ServerSopClass Load(IPersistenceContext read, ServerEntityKey key)
        {
            IServerSopClassEntityBroker broker = read.GetBroker<IServerSopClassEntityBroker>();
            ServerSopClass theObject = broker.Load(key);
            return theObject;
        }
        static public ServerSopClass Insert(ServerSopClass entity)
        {
            using (IUpdateContext update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                ServerSopClass newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public ServerSopClass Insert(IUpdateContext update, ServerSopClass entity)
        {
            IServerSopClassEntityBroker broker = update.GetBroker<IServerSopClassEntityBroker>();
            ServerSopClassUpdateColumns updateColumns = new ServerSopClassUpdateColumns();
            updateColumns.Description = entity.Description;
            updateColumns.NonImage = entity.NonImage;
            updateColumns.SopClassUid = entity.SopClassUid;
            ServerSopClass newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}
