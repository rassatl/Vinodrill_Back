using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class TypeVisiteManager : IDataRepository<TypeVisite>
    {
        readonly VinodrillDBContext? dbContext;

        public TypeVisiteManager() { }

        public TypeVisiteManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(TypeVisite entity)
        {
            await dbContext.TypeVisites.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TypeVisite entityToUpdate, TypeVisite entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdTypeVisite = entity.IdTypeVisite;
            entityToUpdate.LibelleTypeVisite = entity.LibelleTypeVisite;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TypeVisite entity)
        {
            dbContext.TypeVisites.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<TypeVisite>>> GetAll()
        {
            return await dbContext.TypeVisites.ToListAsync();
        }

        public async Task<ActionResult<TypeVisite>> GetById(int id)
        {
            return await dbContext.TypeVisites.FirstOrDefaultAsync(a => a.IdTypeVisite == id);
        }
    }
}
