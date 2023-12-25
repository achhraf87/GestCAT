using GESTCAT.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Contracts
{
    public interface ILivreRepository : IBaseRepository<Livre>
    {
        Task<IReadOnlyList<Livre>> GetAllLivre(bool includeCatalogue);
        Task<Livre> GetLivreById(int id, bool includeCatalogue);
    }
}
