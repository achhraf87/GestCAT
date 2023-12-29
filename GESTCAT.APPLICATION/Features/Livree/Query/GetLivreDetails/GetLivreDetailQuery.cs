using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreDetails;
using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livre.Query.GetLivreDetails
{
    public class GetLivreDetailQuery : IRequest<GetLivreDetailViewModel>
    {
        public int Id { get; set; }
    }
}
