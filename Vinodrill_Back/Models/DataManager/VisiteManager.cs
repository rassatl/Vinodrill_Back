using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class VisiteManager : IDataRepository<Visite>
    {
        readonly VinodrillDBContext? dbContext;

        public VisiteManager() { }

        public VisiteManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Visite entity)
        {
            await dbContext.Visites.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Visite entityToUpdate, Visite entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdVisite = entity.IdVisite;
            entityToUpdate.IdTypeVisite = entity.IdTypeVisite;
            entityToUpdate.IdPartenaire = entity.IdPartenaire;
            entityToUpdate.LibelleVisite = entity.LibelleVisite;
            entityToUpdate.DescriptionVisite = entity.DescriptionVisite;
            entityToUpdate.HoraireVisite = entity.HoraireVisite;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Visite entity)
        {
            dbContext.Visites.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Visite>>> GetAll()
        {
            return await dbContext.Visites.ToListAsync();
        }

        public async Task<ActionResult<Visite>> GetById(int id)
        {
            return await dbContext.Visites.FirstOrDefaultAsync(a => a.IdVisite == id);
        }
    }
}
