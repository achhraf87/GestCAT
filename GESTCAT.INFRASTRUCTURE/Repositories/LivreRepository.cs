using GESTCAT.APPLICATION.Contracts;
using GESTCAT.DOMAIN.Models;
using GESTCAT.INFRASTRUCTURE.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.INFRASTRUCTURE.Repositories
{
    public class LivreRepository : BaseRepository<Livre>, ILivreRepository
    {
        private readonly AppDBContext _appDBContext;
        public LivreRepository(AppDBContext appDBContext) : base(appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<IReadOnlyList<Livre>> GetAllLivre(bool includeAll)
        {
            List<Livre> allLivre = new List<Livre>();
            allLivre = includeAll ? await _appDBContext.Livres.Include(x => x.Catalogues)
                .Include(x => x.Editeur)
                .Include(x => x.Couverture)
                .Include(x => x.Historiques)
                .ToListAsync() : await _appDBContext.Livres.ToListAsync();
            return allLivre;
        }

        public async Task<Livre> GetLivreById(int id, bool includeAll)
        {
            if (includeAll)
            {
                return await _appDBContext.Livres.Include(x => x.Catalogues)
                    .Include(x => x.Editeur)
                .Include(x => x.Couverture)
                .Include(x => x.Historiques)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return await GetByIdAsync(id);
            }
        }
    }
}
