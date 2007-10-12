#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
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
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Ris.Application.Common.Admin.StaffAdmin;
using ClearCanvas.Ris.Application.Common;
using System.Security.Permissions;

namespace ClearCanvas.Ris.Application.Services.Admin.StaffAdmin
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IStaffAdminService))]
    public class StaffAdminService : ApplicationServiceBase, IStaffAdminService
    {
        #region IStaffAdminService Members

        [ReadOperation]
        // note: this operation is not protected with ClearCanvas.Ris.Application.Common.AuthorityTokens.StaffAdmin
        // because it is used in non-admin situations - perhaps we need to create a separate operation???
        public ListStaffResponse ListStaff(ListStaffRequest request)
        {

            SearchResultPage page = new SearchResultPage(request.PageRequest.FirstRow, request.PageRequest.MaxRows);

            StaffAssembler assembler = new StaffAssembler();

            StaffSearchCriteria criteria = new StaffSearchCriteria();
            if (!string.IsNullOrEmpty(request.FirstName))
                criteria.Name.GivenName.StartsWith(request.FirstName);
            if (!string.IsNullOrEmpty(request.LastName))
                criteria.Name.FamilyName.StartsWith(request.LastName);

            return new ListStaffResponse(
                CollectionUtils.Map<Staff, StaffSummary, List<StaffSummary>>(
                    PersistenceContext.GetBroker<IStaffBroker>().Find(criteria, page),
                    delegate(Staff s)
                    {
                        return assembler.CreateStaffSummary(s, PersistenceContext);
                    }));
        }

        [ReadOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.StaffAdmin)]
        public LoadStaffForEditResponse LoadStaffForEdit(LoadStaffForEditRequest request)
        {
            // note that the version of the StaffRef is intentionally ignored here (default behaviour of ReadOperation)
            Staff s = PersistenceContext.Load<Staff>(request.StaffRef);
            StaffAssembler assembler = new StaffAssembler();

            return new LoadStaffForEditResponse(s.GetRef(), assembler.CreateStaffDetail(s, this.PersistenceContext));
        }

        [ReadOperation]
        public LoadStaffEditorFormDataResponse LoadStaffEditorFormData(LoadStaffEditorFormDataRequest request)
        {
            //TODO:  replace "dummy" lists
            List<string> dummyCountries = new List<string>();
            dummyCountries.Add("Canada");

            List<string> dummyProvinces = new List<string>();
            dummyProvinces.Add("Ontario");

            return new LoadStaffEditorFormDataResponse(
                EnumUtils.GetEnumValueList<AddressTypeEnum>(PersistenceContext),
                dummyProvinces,
                dummyCountries,
                (new SimplifiedPhoneTypeAssembler()).GetSimplifiedPhoneTypeChoices(false),
                EnumUtils.GetEnumValueList<StaffTypeEnum>(PersistenceContext)
                );

        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.StaffAdmin)]
        public AddStaffResponse AddStaff(AddStaffRequest request)
        {
            StaffType staffType = EnumUtils.GetEnumValue<StaffType>(request.StaffDetail.StaffType);
            Staff staff = new Staff();

            StaffAssembler assembler = new StaffAssembler();
            assembler.UpdateStaff(request.StaffDetail, staff);

            PersistenceContext.Lock(staff, DirtyState.New);

            // ensure the new staff is assigned an OID before using it in the return value
            PersistenceContext.SynchState();

            return new AddStaffResponse(assembler.CreateStaffSummary(staff, PersistenceContext));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.StaffAdmin)]
        public UpdateStaffResponse UpdateStaff(UpdateStaffRequest request)
        {
            Staff staff = PersistenceContext.Load<Staff>(request.StaffRef, EntityLoadFlags.CheckVersion);

            StaffAssembler assembler = new StaffAssembler();
            assembler.UpdateStaff(request.StaffDetail, staff);

            return new UpdateStaffResponse(assembler.CreateStaffSummary(staff, PersistenceContext));
        }

        #endregion
    }
}
