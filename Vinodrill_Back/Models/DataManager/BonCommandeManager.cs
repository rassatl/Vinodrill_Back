using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class BonCommandeManager : IBonCommandeRepository
    {
        readonly VinodrillDBContext? dbContext;

        public BonCommandeManager() { }

        public BonCommandeManager(VinodrillDBContext context) { dbContext = context; }

        public Task Add(BonCommande entity)
        {
            return null;
        }

        public Task Delete(BonCommande entity)
        {
            return null;
        }

        public Task<ActionResult<IEnumerable<BonCommande>>> GetAll()
        {
            return null;
        }

        public async Task<ActionResult<BonCommande>> GetById(int refcommande)
        {
            return null;
        }

        public async Task<ActionResult<BonCommande>> GetByRefCommande(int refcommande)
        {
            return await dbContext.BonCommandes.FirstOrDefaultAsync(a => a.RefCommande == refcommande);
        }

        public Task Update(BonCommande entityToUpdate, BonCommande entity)
        {
            return null;
        }
    }
}
