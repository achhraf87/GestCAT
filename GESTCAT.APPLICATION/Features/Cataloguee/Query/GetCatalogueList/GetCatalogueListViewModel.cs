using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Cataloguee.Query.GetCatalogueList
{
    public class GetCatalogueListViewModel
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public DateTime? DateModif { get; set; }

        public int? LivreId { get; set; }
    }
}
