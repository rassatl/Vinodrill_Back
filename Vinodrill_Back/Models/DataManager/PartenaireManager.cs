using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class PartenaireManager : IDataRepository<Partenaire>
    {
        readonly VinodrillDBContext? dbContext;

        public PartenaireManager() { }

        public PartenaireManager(VinodrillDBContext context) { dbContext = context; }

        public Task Add(Partenaire entity)
        {
            return null;
        }

        public Task Delete(Partenaire entity)
        {
            return null;
        }

        public async Task<ActionResult<IEnumerable<Partenaire>>> GetAll()
        {
            return await dbContext.Partenaires.ToListAsync();
        }

        public async Task<ActionResult<Partenaire>> GetById(int id)
        {
            return await dbContext.Partenaires.FirstOrDefaultAsync(a => a.IdPartenaire == id);
        }

        public Task Update(Partenaire entityToUpdate, Partenaire entity)
        {
            return null;
        }
    }
}
