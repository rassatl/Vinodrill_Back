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

        public async Task Add(Partenaire entity)
        {
            await dbContext.Partenaires.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Partenaire entityToUpdate, Partenaire entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdPartenaire = entity.IdPartenaire;
            entityToUpdate.NomPartenaire = entity.NomPartenaire;
            entityToUpdate.RuePartenaire = entity.RuePartenaire;
            entityToUpdate.CpPartenaire = entity.CpPartenaire;
            entityToUpdate.VillePartenaire = entity.VillePartenaire ;
            entityToUpdate.PhotoPartenaire = entity.PhotoPartenaire;
            entityToUpdate.EmailPartenaire = entity.EmailPartenaire;
            entityToUpdate.Contact = entity.Contact;
            entityToUpdate.DetailPartenaire = entity.DetailPartenaire;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Partenaire entity)
        {
            dbContext.Partenaires.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Partenaire>>> GetAll()
        {
            return await dbContext.Partenaires.ToListAsync();
        }

        public async Task<ActionResult<Partenaire>> GetById(int id)
        {
            return await dbContext.Partenaires.FirstOrDefaultAsync(a => a.IdPartenaire == id);
        }
    }
}
