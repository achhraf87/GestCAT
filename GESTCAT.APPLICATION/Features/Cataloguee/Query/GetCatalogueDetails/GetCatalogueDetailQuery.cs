using GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogDetails
{
    public class GetCatalogueDetailQuery : IRequest<GetCatalogueDetailViewModel>
    {
       public int Id { get; set; }
    }
}
