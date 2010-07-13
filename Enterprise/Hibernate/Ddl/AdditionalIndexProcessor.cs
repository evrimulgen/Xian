﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
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
using System.Text;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using Iesi.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Mapping;

namespace ClearCanvas.Enterprise.Hibernate.Ddl
{
    /// <summary>
    /// Adds additional indexes to the Hibernate relational model, according to what is defined in *.dbi.xml files
    /// that are found in plugins.
    /// </summary>
    /// <remarks>
    /// This processor scans all plugins for *.dbi.xml resource files.  These files contain instructions for creating
    /// specific indexes in an XML format. See the file AdditionalIndexProcessor.dbi.xml.
    /// </remarks>
    class AdditionalIndexProcessor : IndexCreatorBase
    {
        public override void Process(Configuration config)
        {
            Dictionary<string, Table> tables = GetTables(config);

            // create a resource resolver that will scan all plugins
			// TODO: we should only scan plugins that are tied to the specified PersistentStore, but there is currently no way to know this
            IResourceResolver resolver = new ResourceResolver(
                CollectionUtils.Map<PluginInfo, Assembly>(Platform.PluginManager.Plugins,
                    delegate(PluginInfo pi) { return pi.Assembly; }).ToArray());

            // find all dbi resources
            Regex rx = new Regex("dbi.xml$", RegexOptions.Compiled|RegexOptions.IgnoreCase);
            string[] dbiFiles = resolver.FindResources(rx);

            foreach (string dbiFile in dbiFiles)
            {
                using(Stream stream = resolver.OpenResource(dbiFile))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(stream);
                    foreach(XmlElement indexElement in xmlDoc.SelectNodes("indexes/index"))
                    {
                        ProcessIndex(indexElement, tables);
                    }
                }
            }

        }

        private void ProcessIndex(XmlElement indexElement, Dictionary<string, Table> tables)
        {
            string tableName = indexElement.GetAttribute("table");
            List<string> columnNames = CollectionUtils.Map(indexElement.GetAttribute("columns").Split(','), (string s) => s.Trim());

            if(!string.IsNullOrEmpty(tableName) && columnNames.Count > 0)
            {
                Table table;
                if(!tables.TryGetValue(tableName, out table))
					throw new DdlException(
						string.Format("An additional index refers to a table ({0}) that does not exist.", table.Name),
						null);

            	var columns = new List<Column>();
            	foreach (var columnName in columnNames)
            	{
            		var column = CollectionUtils.SelectFirst(table.ColumnIterator, col => col.Name == columnName);
					// bug #6994: could be that the index file specifies a column name that does not actually exist, so we need to check for nulls
					if (column == null)
						throw new DdlException(
							string.Format("An additional index on table {0} refers to a column ({1}) that does not exist.", table.Name, columnName),
							null);
					columns.Add(column);
				}

                CreateIndex(table, columns);
            }
        }


		private Dictionary<string, Table> GetTables(Configuration config)
        {
            // build a set of all tables known to NH
            Dictionary<string, Table> tableSet = new Dictionary<string, Table>();
            foreach (PersistentClass c in config.ClassMappings)
            {
                tableSet[c.Table.Name] = c.Table;
            }

            foreach (Collection mapping in config.CollectionMappings)
            {
                tableSet[mapping.CollectionTable.Name] = mapping.CollectionTable;
                tableSet[mapping.Table.Name] = mapping.Table;
            }
            return tableSet;
        }
    }
}
