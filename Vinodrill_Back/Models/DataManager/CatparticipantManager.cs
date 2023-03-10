using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Vinodrill_Back.Models.DataManager
{
    public class CatparticipantManager : IDataRepository<CatParticipant>
    {
        readonly VinodrillDBContext? dbContext;

        public CatparticipantManager() { }

        public CatparticipantManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(CatParticipant entity)
        {
            await dbContext.Catparticipants.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
            
        public async Task Update(CatParticipant entityToUpdate, CatParticipant entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdCategorieParticipant = entity.IdCategorieParticipant;
            entityToUpdate.NomCategorieParticipant = entity.NomCategorieParticipant;
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(CatParticipant entity)
        {
            dbContext.Catparticipants.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<CatParticipant>>> GetAll()
        {
            return await dbContext.Catparticipants.ToListAsync();
        }

        public async Task<ActionResult<CatParticipant>> GetById(int id)
        {
            return await dbContext.Catparticipants.FirstOrDefaultAsync(a => a.IdCategorieParticipant == id);
        }
    }
}
