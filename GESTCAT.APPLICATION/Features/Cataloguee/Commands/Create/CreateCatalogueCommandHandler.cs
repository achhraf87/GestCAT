using AutoMapper;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.APPLICATION.Features.Livree.Commands.Create;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create;
using GESTCAT.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create
{
    public class CreateCatalogueCommandHandler : IRequestHandler<CreateCatalogueCommand, int>
    {
        private readonly ICatalogueRepository _Catgegory;
        private readonly IMapper _Imapper; 
        private readonly CreateCommandValidator _validations;

        public CreateCatalogueCommandHandler(ICatalogueRepository Catgegory, IMapper Imapper, CreateCommandValidator validations = null)
        {
            _Catgegory = Catgegory;
            _Imapper = Imapper;
            _validations = validations;
        }
        public async Task<int> Handle(CreateCatalogueCommand request, CancellationToken cancellationToken)
        {
            Catalogue cat = _Imapper.Map<Catalogue>(request);

            var validationResult = await _validations.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));

                throw new ValidationException($"Catalogue is not valid: {errors}");
            }

            cat = await _Catgegory.AddAsync(cat);

            return cat.Id;
        }

        
    }
}
