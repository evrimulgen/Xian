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
using ClearCanvas.Ris.Application.Common.Admin.ModalityAdmin;
using System.Security.Permissions;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Application.Services.Admin.ModalityAdmin
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IModalityAdminService))]
    public class ModalityAdminService : ApplicationServiceBase, IModalityAdminService
    {
        #region IModalityAdminService Members

        [ReadOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.ModalityAdmin)]
        public ListAllModalitiesResponse ListAllModalities(ListAllModalitiesRequest request)
        {
            ModalitySearchCriteria criteria = new ModalitySearchCriteria();
            SearchResultPage page = new SearchResultPage(request.PageRequest.FirstRow, request.PageRequest.MaxRows);

            ModalityAssembler assembler = new ModalityAssembler();
            return new ListAllModalitiesResponse(
                CollectionUtils.Map<Modality, ModalitySummary, List<ModalitySummary>>(
                    PersistenceContext.GetBroker<IModalityBroker>().Find(criteria, page),
                    delegate(Modality m)
                    {
                        return assembler.CreateModalitySummary(m);
                    }));
        }

        [ReadOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.ModalityAdmin)]
        public LoadModalityForEditResponse LoadModalityForEdit(LoadModalityForEditRequest request)
        {
            // note that the version of the ModalityRef is intentionally ignored here (default behaviour of ReadOperation)
            Modality m = PersistenceContext.Load<Modality>(request.ModalityRef);
            ModalityAssembler assembler = new ModalityAssembler();

            return new LoadModalityForEditResponse(m.GetRef(), assembler.CreateModalityDetail(m));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.ModalityAdmin)]
        public AddModalityResponse AddModality(AddModalityRequest request)
        {
            Modality modality = new Modality();
            ModalityAssembler assembler = new ModalityAssembler();
            assembler.UpdateModality(request.ModalityDetail, modality);

            PersistenceContext.Lock(modality, DirtyState.New);

            // ensure the new modality is assigned an OID before using it in the return value
            PersistenceContext.SynchState();

            return new AddModalityResponse(assembler.CreateModalitySummary(modality));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.ModalityAdmin)]
        public UpdateModalityResponse UpdateModality(UpdateModalityRequest request)
        {
            Modality modality = PersistenceContext.Load<Modality>(request.ModalityRef, EntityLoadFlags.CheckVersion);

            ModalityAssembler assembler = new ModalityAssembler();
            assembler.UpdateModality(request.ModalityDetail, modality);

            return new UpdateModalityResponse(assembler.CreateModalitySummary(modality));
        }

        #endregion

    }
}
