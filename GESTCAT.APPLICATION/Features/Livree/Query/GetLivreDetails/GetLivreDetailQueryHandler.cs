using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Livre.Query.GetLivreDetails;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livree.Query.GetLivreDetails
{
    public class GetLivreDetailQueryHandler : IRequestHandler<GetLivreDetailQuery, GetLivreDetailViewModel>
    {
        private readonly ILivreRepository _livreRepository;
        private readonly IMapper _mapper;
        public GetLivreDetailQueryHandler(ILivreRepository livreRepository, IMapper mapper)
        {
            _livreRepository = livreRepository;
            _mapper = mapper;
        }

        public async Task<GetLivreDetailViewModel> Handle(GetLivreDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _livreRepository.GetLivreById(request.Id, true);

            if (res.DatePublication != null && res.DatePublication.Value < DateTime.UtcNow.AddYears(-5))
            {
                throw new Exception("Ce livre a été publié il y a plus de 5 ans et n'est pas disponible.");
            }

            return _mapper.Map<GetLivreDetailViewModel>(res);
        }
    }
}
