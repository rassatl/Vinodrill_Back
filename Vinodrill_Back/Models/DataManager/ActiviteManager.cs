using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class ActiviteManager : IDataRepository<Activite>
    {
        readonly VinodrillDBContext? dbContext;

        public ActiviteManager() { }

        public ActiviteManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Activite entity)
        {
            await dbContext.Activites.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Activite entityToUpdate, Activite entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.RueRdv = entity.RueRdv;
            entityToUpdate.CpRdv = entity.CpRdv;
            entityToUpdate.VilleRdv = entity.VilleRdv;
            entityToUpdate.LibelleActivite = entity.LibelleActivite;
            entityToUpdate.DescriptionActivite = entity.DescriptionActivite;
            entityToUpdate.HoraireActivite = entity.HoraireActivite;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Activite entity)
        {
            dbContext.Activites.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Activite>>> GetAll()
        {
            return await dbContext.Activites.ToListAsync();
        }

        public async Task<ActionResult<Activite>> GetById(int id)
        {
            return await dbContext.Activites.FirstOrDefaultAsync(a => a.IdActivite == id);
        }
    }
}
