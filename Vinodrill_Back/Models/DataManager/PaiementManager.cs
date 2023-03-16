using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class PaiementManager : IDataRepository<Paiement>
    {
        readonly VinodrillDBContext? dbContext;

        public PaiementManager() { }

        public PaiementManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Paiement entity)
        {
            dbContext.Paiements.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Paiement entityToUpdate, Paiement entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdPaiement = entity.IdPaiement;
            entityToUpdate.IdClientPaiement = entity.IdClientPaiement;
            entityToUpdate.LibellePaiement = entity.LibellePaiement;
            entityToUpdate.PreferencePaiement = entity.PreferencePaiement;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Paiement entity)
        {
            dbContext.Paiements.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Paiement>>> GetAll()
        {
            return await dbContext.Paiements.ToListAsync();
        }

        public async Task<ActionResult<Paiement>> GetById(int id)
        {
            return await dbContext.Paiements.FirstOrDefaultAsync(a => a.IdPaiement == id);
        }
    }
}