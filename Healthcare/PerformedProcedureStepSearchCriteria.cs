using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Workflow;

namespace ClearCanvas.Healthcare {

    /// <summary>
    /// Search criteria for <see cref="PerformedProcedureStep"/> entity
    /// This file is machine generated - changes will be lost.
    /// </summary>
	public partial class PerformedProcedureStepSearchCriteria : PerformedStepSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public PerformedProcedureStepSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public PerformedProcedureStepSearchCriteria(string key)
			:base(key)
		{
		}

		
		/// <summary>
		/// Constructor to search by EntityRef
		/// </summary>
		public PerformedProcedureStepSearchCriteria(EntityRef entityRef)
		{
            this.SubCriteria["OID"] = new SearchCondition<object>("OID");
            ((ISearchCondition<object>)this.SubCriteria["OID"]).EqualTo(EntityRefUtils.GetOID(entityRef));
		}
		
	  	public ProcedureStepPerformerSearchCriteria Performer
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Performer"))
	  			{
	  				this.SubCriteria["Performer"] = new ProcedureStepPerformerSearchCriteria("Performer");
	  			}
	  			return (ProcedureStepPerformerSearchCriteria)this.SubCriteria["Performer"];
	  		}
	  	}
	}
}
