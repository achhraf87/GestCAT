using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Livre.Query.GetLivreList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livree.Query.GetLivreList
{
    public class GetLivreListQueryHandler : IRequestHandler<GetLivreListQuery, List<GetLivreListViewModal>>
    {
        private readonly ILivreRepository _livre;
        private readonly IMapper _mapper;
        public GetLivreListQueryHandler(ILivreRepository livre, IMapper mapper)
        {
            _livre = livre;
            _mapper = mapper;
        }

        public async Task<List<GetLivreListViewModal>> Handle(GetLivreListQuery request, CancellationToken cancellationToken)
        {
            var livre = await _livre.GetAllLivre(true);
            return _mapper.Map<List<GetLivreListViewModal>>(livre);
        }
    }
}
