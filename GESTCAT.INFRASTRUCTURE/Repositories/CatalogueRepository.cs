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
    public class CatalogueRepository : BaseRepository<Catalogue>, ICatalogueRepository
    {
        private readonly AppDBContext _dbContext;
        public CatalogueRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Catalogue>> GetAllCatalogue(bool includeCat)
        {
            List<Catalogue> allPosts = new List<Catalogue>();
            allPosts = includeCat ? await _dbContext.Catalogues.Include(x => x.Livre).ToListAsync() : await _dbContext.Catalogues.ToListAsync();
            return allPosts;
            //if (includeCat)
            //{
            //    return await _dbContext.Catalogues.Include(x => x.LivreId).ToListAsync();
            //}
            //else
            //{
            //    return await _dbContext.Catalogues.ToListAsync();
            //}
        }

        public async Task<Catalogue> GetCatalogueById(int id, bool includeCatalogue)
        {
            if (includeCatalogue)
            {
                return await _dbContext.Catalogues.Include(x => x.Livre).FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return await GetByIdAsync(id);
            }
        }

        
    }
}
