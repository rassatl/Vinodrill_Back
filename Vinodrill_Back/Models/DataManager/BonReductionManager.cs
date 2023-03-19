using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class BonReductionManager : IBonreductionRepository
    {
        readonly VinodrillDBContext? dbContext;

        public BonReductionManager() { }

        public BonReductionManager(VinodrillDBContext context) { dbContext = context; }
        
        public Task Add(BonReduction entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(BonReduction entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<BonReduction>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<BonReduction>> check(string codeCoupon)
        {
            var bonReduction = await dbContext.BonReductions.FirstOrDefaultAsync(b => b.CodeBonReduction == codeCoupon);

            return bonReduction;
        }

        public async Task<ActionResult<BonReduction>> GetById(int id)
        {
            return await dbContext.BonReductions.FindAsync(id);
        }

        public Task Update(BonReduction entityToUpdate, BonReduction entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.CodeBonReduction = entity.CodeBonReduction;
            entityToUpdate.RefCommande = entity.RefCommande;
            entityToUpdate.DateValidite = entity.DateValidite;
            entityToUpdate.EstValide = entity.EstValide;

            return dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<BonReduction>> getByCode(string codeCoupon)
        {
            var bonReduction = await dbContext.BonReductions.FirstOrDefaultAsync(b => b.CodeBonReduction == codeCoupon);

            return bonReduction;
        }

        public async Task<ActionResult<decimal>> getAmount(BonReduction bonReduction)
        {
            var commande = await dbContext.Commandes.FindAsync(bonReduction.RefCommande);
            var montant = commande.PrixCommande;

            return montant;
        }
    }
}