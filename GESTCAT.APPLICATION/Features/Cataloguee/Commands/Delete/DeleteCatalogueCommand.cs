using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Commands.Delete
{
    public class DeleteCatalogueCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
