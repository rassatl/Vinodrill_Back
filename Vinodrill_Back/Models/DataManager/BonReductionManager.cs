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

        public async Task<ActionResult<BonReduction>> GetByCode(string codeCoupon)
        {
            return await dbContext.BonReductions.Where(b => b.CodeBonReduction == codeCoupon).FirstOrDefaultAsync();
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
    }
}