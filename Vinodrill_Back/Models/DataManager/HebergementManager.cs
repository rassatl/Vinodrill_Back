using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class HebergementManager : IDataRepository<Hebergement>
    {
        readonly VinodrillDBContext? dbContext;

        public HebergementManager() { }

        public HebergementManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Hebergement entity)
        {
            await dbContext.Hebergement.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task Delete(Hebergement entity)
        {
            return null;
        }

        public Task<ActionResult<IEnumerable<Hebergement>>> GetAll()
        {
            return null;
        }

        public Task<ActionResult<Hebergement>> GetById(int id)
        {
            return null;
        }

        public Task Update(Hebergement entityToUpdate, Hebergement entity)
        {
            return null;
        }
    }
}
