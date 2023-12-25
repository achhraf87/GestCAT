using FluentValidation;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCatalogueCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Nom).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(p => p.DateModif).NotEmpty().NotNull();
        }
    }
}
