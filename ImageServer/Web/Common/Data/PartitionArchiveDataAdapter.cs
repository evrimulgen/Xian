#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
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

using System;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.ImageServer.Model;
using ClearCanvas.ImageServer.Model.Brokers;
using ClearCanvas.ImageServer.Model.EntityBrokers;
using ClearCanvas.ImageServer.Model.Parameters;

namespace ClearCanvas.ImageServer.Web.Common.Data
{
    /// <summary>
    /// Used to create/update/delete server partition entries in the database.
    /// </summary>
    public class PartitionArchiveDataAdapter :
        BaseAdaptor
            <PartitionArchive, IPartitionArchiveEntityBroker, PartitionArchiveSelectCriteria, PartitionArchiveUpdateColumns>
    {
        #region Public methods

        /// <summary>
        /// Gets a list of all server partitions.
        /// </summary>
        /// <returns></returns>
        public IList<PartitionArchive> GetPartitionArchives()
        {
            return Get();
        }

        public IList<PartitionArchive> GetPartitionArchives(PartitionArchiveSelectCriteria criteria)
        {
            return Get(criteria);
        }

        /// <summary>
        /// Creats a new server parition.
        /// </summary>
        /// <param name="partition"></param>
        public bool AddPartitionArchive(PartitionArchive partition)
        {
            PartitionArchiveAdaptor adaptor = new PartitionArchiveAdaptor();
            PartitionArchiveUpdateColumns columns = new PartitionArchiveUpdateColumns();
                
            columns.Description = partition.Description;
            columns.ArchiveDelayHours = partition.ArchiveDelayHours;
            columns.ArchiveTypeEnum = partition.ArchiveTypeEnum;
            columns.ConfigurationXml = partition.ConfigurationXml;
            columns.Enabled = partition.Enabled;
            columns.ReadOnly = partition.ReadOnly;
            columns.ServerPartitionKey = partition.ServerPartitionKey;

            adaptor.Add(columns);

            return true;
        }

        public bool Update(PartitionArchive partition)
        {
            PartitionArchiveUpdateColumns parms = new PartitionArchiveUpdateColumns();
            parms.Description = partition.Description;

            return Update(partition.Key, parms);
        }

        #endregion Public methods
    }
}

