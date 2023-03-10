using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class SejourManager : IDataRepository<Sejour>
    {
        readonly VinodrillDBContext? dbContext;

        public SejourManager() { }

        public SejourManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Sejour entity)
        {
            await dbContext.Sejours.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Sejour entityToUpdate, Sejour entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Sejour entity)
        {
            dbContext.Sejours.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAll()
        {
            // get theme and destination
            return await dbContext.Sejours
                .Include(s => s.ThemeSejourNavigation)
                .Include(s => s.DestinationSejourNavigation)
                .ToListAsync();
        }

        public async Task<ActionResult<Sejour>> GetById(int id)
        {
            return await dbContext.Sejours.FirstOrDefaultAsync(a => a.IdSejour == id);
        }
    }
}
