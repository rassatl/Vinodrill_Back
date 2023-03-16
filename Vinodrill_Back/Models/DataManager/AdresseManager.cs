using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class AdresseManager : IAdresseRepository
    {
        readonly VinodrillDBContext? dbContext;

        public AdresseManager() { }

        public AdresseManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Adresse entity)
        {
            await dbContext.Adresses.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Adresse entityToUpdate, Adresse entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdClient = entity.IdClient;
            entityToUpdate.VilleAdresse = entity.VilleAdresse;
            entityToUpdate.RueAdresse = entity.RueAdresse;
            entityToUpdate.LibelleAdresse = entity.LibelleAdresse;
            entityToUpdate.PaysAdresse = entity.PaysAdresse;
            entityToUpdate.CodePostalAdresse = entity.CodePostalAdresse;
            entityToUpdate.IdAdresse = entity.IdAdresse;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Adresse entity)
        {
            dbContext.Adresses.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<Adresse>> GetById(int id)
        {
            return await dbContext.Adresses.FirstOrDefaultAsync(a => a.IdAdresse == id);
        }

        public Task<ActionResult<IEnumerable<Adresse>>> GetAll()
        {
            return null;
        }
    }
}
