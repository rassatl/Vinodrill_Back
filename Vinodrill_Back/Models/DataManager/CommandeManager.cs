using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class CommandeManager : IcommandeRepository
    {
        readonly VinodrillDBContext? dbContext;

        public CommandeManager() { }

        public CommandeManager(VinodrillDBContext context) { dbContext = context; }

        async Task<int> IcommandeRepository.Add(Commande entity)
        {
            await dbContext.Commandes.AddAsync(entity);
            await dbContext.SaveChangesAsync();    

            return entity.RefCommande;        
        }

        public async Task Update(Commande entityToUpdate, Commande entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.Quantite = entity.Quantite;
            entityToUpdate.EstCheque = entity.EstCheque;
            entityToUpdate.IdClient = entity.IdClient;
            entityToUpdate.CheminFacture = entity.CheminFacture;
            entityToUpdate.DateCommande = entity.DateCommande;
            entityToUpdate.Message = entity.Message;
            entityToUpdate.IdPaiement = entity.IdPaiement;
            entityToUpdate.PrixCommande = entity.PrixCommande;
            entityToUpdate.RefCommande = entity.RefCommande;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Commande entity)
        {
            dbContext.Commandes.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Commande>>> GetAll()
        {
            return await dbContext.Commandes.ToListAsync();
        }

        public async Task<ActionResult<Commande>> GetById(int id)
        {
            return await dbContext.Commandes.FirstOrDefaultAsync(a => a.RefCommande == id);
        }

        Task IDataRepository<Commande>.Add(Commande entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
