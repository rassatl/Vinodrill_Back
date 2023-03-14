using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class ClientManager : IDataRepository<User>
    {
        readonly VinodrillDBContext? dbContext;

        public ClientManager() { }

        public ClientManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(User entity)
        {
            await dbContext.Clients.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(User entityToUpdate, User entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdClient = entity.IdClient;
            entityToUpdate.IdCbClient = entity.IdCbClient;
            entityToUpdate.IdAvisClient = entity.IdAvisClient;
            entityToUpdate.EmailClient = entity.EmailClient;
            entityToUpdate.SexeClient = entity.SexeClient;
            entityToUpdate.NomClient = entity.NomClient;
            entityToUpdate.PrenomClient = entity.PrenomClient;
            entityToUpdate.MotDePasseClient= entity.MotDePasseClient;
            entityToUpdate.DateNaissanceClient = entity.DateNaissanceClient;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            dbContext.Clients.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task<ActionResult<User>> GetById(int id)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(a => a.IdClient == id);
        }
    }
}
