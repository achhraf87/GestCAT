using GESTCAT.APPLICATION.Features.Livree.Query.GetLivreList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livre.Query.GetLivreList
{
    public class GetLivreListQuery : IRequest<List<GetLivreListViewModal>>
    {

    }
}
