using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueDetails
{
    public class GetCatalogueDetailQueryHandler : IRequestHandler<GetCatalogueDetailQuery, GetCatalogueDetailViewModel>
    {
        private readonly ICatalogueRepository _catalogue;
        private readonly IMapper _mapper;

        public GetCatalogueDetailQueryHandler(ICatalogueRepository catalogue, IMapper mapper)
        {
            _catalogue = catalogue;
            _mapper = mapper;
        }
        public async Task<GetCatalogueDetailViewModel> Handle(GetCatalogueDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _catalogue.GetCatalogueById(request.Id, true);
            return _mapper.Map<GetCatalogueDetailViewModel>(res);
        }
    }
}
