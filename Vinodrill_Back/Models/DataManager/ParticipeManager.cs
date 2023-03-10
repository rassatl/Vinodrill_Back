using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class ParticipeManager : IDataRepository<Participe>
    {
        readonly VinodrillDBContext? dbContext;

        public ParticipeManager() { }

        public ParticipeManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Participe entity)
        {
            await dbContext.Participes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Participe entityToUpdate, Participe entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdCategorieParticipant = entity.IdCategorieParticipant;
            entityToUpdate.IdSejour = entity.IdSejour;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Participe entity)
        {
            dbContext.Participes.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Participe>>> GetAll()
        {
            return await dbContext.Participes.ToListAsync();
        }

        public async Task<ActionResult<Participe>> GetById(int id)
        {
            return null;
        }
    }
}
