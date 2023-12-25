using GESTCAT.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Contracts
{
    public interface ICatalogueRepository : IBaseRepository<Catalogue>
    {
        Task<IReadOnlyList<Catalogue>> GetAllCatalogue(bool includeLivre);
        Task<Catalogue> GetCatalogueById(int id, bool includeLivre);
    }
}
