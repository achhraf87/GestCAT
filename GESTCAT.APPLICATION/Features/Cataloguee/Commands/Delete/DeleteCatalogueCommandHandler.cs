using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Delete;
using GESTCAT.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Delete
{
    internal class DeleteCatalogueCommandHandler : IRequestHandler<DeleteCatalogueCommand, int>
    {

        private readonly ICatalogueRepository _Catego;
        private readonly IMapper _mapper;
        public DeleteCatalogueCommandHandler(ICatalogueRepository cat,IMapper mapper)
        {
            _Catego = cat;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteCatalogueCommand request, CancellationToken cancellationToken)
        {
            Catalogue cat = _mapper.Map<Catalogue>(request.Id);
             await _Catego.DeleteAsync(cat);
            return 1;
        }
    }
}
