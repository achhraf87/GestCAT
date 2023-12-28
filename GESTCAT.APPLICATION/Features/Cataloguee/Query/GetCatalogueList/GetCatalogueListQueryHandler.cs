using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogList;
using GESTCAT.APPLICATION.Features.Livre.Query.GetLivreList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList
{
    public class GetCatalogueListQueryHandler : IRequestHandler<GetCatalogueListQuery, List<GetCatalogueListViewModel>>
    {
        private readonly ICatalogueRepository _catRepository;
        private readonly IMapper _mapper;
        public GetCatalogueListQueryHandler(ICatalogueRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }
        public async Task<List<GetCatalogueListViewModel>> Handle(GetCatalogueListQuery request, CancellationToken cancellationToken)
        {
            var catalogue = await _catRepository.GetAllCatalogue(true);
            return _mapper.Map<List<GetCatalogueListViewModel>>(catalogue);
        }
    }
}
