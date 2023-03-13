using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class BonCommandeManager : IDataRepository<BonCommande>
    {
        readonly VinodrillDBContext? dbContext;

        public BonCommandeManager() { }

        public BonCommandeManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(BonCommande entity)
        {
            await dbContext.BonCommandes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(BonCommande entityToUpdate, BonCommande entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdBonCommande = entity.IdBonCommande;
            entityToUpdate.RefCommande = entity.RefCommande;
            entityToUpdate.CodeBonCommande = entity.CodeBonCommande;
            entityToUpdate.DateValidite = entity.DateValidite;
            entityToUpdate.EstValide = entity.EstValide;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(BonCommande entity)
        {
            dbContext.BonCommandes.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<BonCommande>>> GetAll()
        {
            return await dbContext.BonCommandes.ToListAsync();
        }

        public async Task<ActionResult<BonCommande>> GetById(int id)
        {
            return await dbContext.BonCommandes.FirstOrDefaultAsync(a => a.IdBonCommande == id);
        }
    }
}
