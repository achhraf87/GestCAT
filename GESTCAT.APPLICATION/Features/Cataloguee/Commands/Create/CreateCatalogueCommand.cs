using GESTCAT.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create
{
    public class CreateCatalogueCommand :IRequest<int>
    {

        public string? Nom { get; set; }

        public DateTime? DateModif { get; set; }

        public int? LivreId { get; set; }

    }
}
