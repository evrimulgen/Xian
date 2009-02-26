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
using System.Text;
using ClearCanvas.Enterprise.Hibernate.Ddl.Migration;
using NHibernate.Cfg;
using NHibernate.Dialect;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Enterprise.Hibernate.Ddl
{
    /// <summary>
    /// Generates scripts to create the tables, foreign key constraints, and indexes.
    /// </summary>
    class RelationalSchemaGenerator : IDdlScriptGenerator
    {
    	private readonly EnumOptions _enumOption;

		public RelationalSchemaGenerator(EnumOptions enumOption)
		{
			_enumOption = enumOption;
		}

        #region IDdlScriptGenerator Members

        public string[] GenerateCreateScripts(Configuration config, Dialect dialect)
        {
			//List<string> scripts = new List<string>(config.GenerateSchemaCreationScript(dialect));
			//List<string> createTables = CollectionUtils.Select(scripts,
			//    delegate(string s) { return s.StartsWith("create table", StringComparison.InvariantCultureIgnoreCase); });
			//List<string> alterTables = CollectionUtils.Select(scripts,
			//    delegate(string s) { return s.StartsWith("alter table", StringComparison.InvariantCultureIgnoreCase); });
			//List<string> createIndexes = CollectionUtils.Select(scripts,
			//    delegate(string s) { return s.StartsWith("create index", StringComparison.InvariantCultureIgnoreCase); });

			//// for some reason, Hibernate does not qualify the table names when generating index scripts
			//// need to qualify them using this hack
			//string schemaName = config.GetProperty(NHibernate.Cfg.Environment.DefaultSchema);
			//string replacement = string.Format(" on {0}.", schemaName);
			//createIndexes = CollectionUtils.Map<string, string>(createIndexes,
			//    delegate(string s) { return s.Replace(" on ", replacement); });

			//// sort each group of statements alphabetically
			//createTables.Sort();
			//alterTables.Sort();
			//createIndexes.Sort();

			//List<string> sortedScripts = new List<string>();
			//sortedScripts.AddRange(createTables);
			//sortedScripts.AddRange(alterTables);
			//sortedScripts.AddRange(createIndexes);

			//return sortedScripts.ToArray();

			RelationalModelInfo currentModel = new RelationalModelInfo(config, dialect);
			RelationalModelInfo baselineModel = new RelationalModelInfo();		// baseline model is empty

            return GetScripts(config, dialect, baselineModel, currentModel);
		}

    	public string[] GenerateUpgradeScripts(Configuration config, Dialect dialect, RelationalModelInfo baselineModel)
    	{
    		RelationalModelInfo currentModel = new RelationalModelInfo(config, dialect);

    		return GetScripts(config, dialect, baselineModel, currentModel);
    	}

        private string[] GetScripts(Configuration config, Dialect dialect, RelationalModelInfo baselineModel, RelationalModelInfo currentModel)
    	{
    		RelationalModelComparator comparator = new RelationalModelComparator(_enumOption);
    		List<Change> changes = comparator.CompareDatabases(baselineModel, currentModel);

    		IRenderer renderer = Renderer.GetRenderer(config, dialect);

    		List<Statement> statements = new List<Statement>();
    		foreach (Change change in changes)
    		{
    			statements.AddRange(change.GetStatements(renderer));
    		}

    		return CollectionUtils.Map<Statement, string>(statements,
    				delegate(Statement s) { return s.Sql; }).ToArray();
    	}

    	public string[] GenerateDropScripts(Configuration config, Dialect dialect)
        {
            return new string[]{};
        }

        #endregion
    }
}
