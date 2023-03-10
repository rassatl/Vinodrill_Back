using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class SocieteManager : IDataRepository<Societe>
    {
        readonly VinodrillDBContext? dbContext;

        public SocieteManager() { }

        public SocieteManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Societe entity)
        {
            await dbContext.Societes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Societe entityToUpdate, Societe entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdPartenaire = entity.IdPartenaire;
            entityToUpdate.IdTypeActivite = entity.IdTypeActivite;
            entityToUpdate.NomPartenaire = entity.NomPartenaire;
            entityToUpdate.RuePartenaire = entity.RuePartenaire;
            entityToUpdate.CpPartenaire = entity.CpPartenaire;
            entityToUpdate.VillePartenaire = entity.VillePartenaire;
            entityToUpdate.PhotoPartenaire = entity.PhotoPartenaire;
            entityToUpdate.EmailPartenaire = entity.EmailPartenaire;
            entityToUpdate.Contact = entity.Contact;
            entityToUpdate.DetailPartenaire = entity.DetailPartenaire;


            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Societe entity)
        {
            dbContext.Societes.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Societe>>> GetAll()
        {
            return await dbContext.Societes.ToListAsync();
        }

        public async Task<ActionResult<Societe>> GetById(int id)
        {
            return await dbContext.Societes.FirstOrDefaultAsync(a => a.IdPartenaire == id);
        }
    }
}
