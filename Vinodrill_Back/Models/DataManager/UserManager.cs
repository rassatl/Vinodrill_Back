using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.Auth;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class UserManager : IUserRepository
    {
        readonly VinodrillDBContext? dbContext;

        public UserManager() { }

        public UserManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(User entity)
        {
            await dbContext.Clients.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(User entityToUpdate, User entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdClient = entity.IdClient;
            entityToUpdate.EmailClient = entity.EmailClient;
            entityToUpdate.SexeClient = entity.SexeClient;
            entityToUpdate.NomClient = entity.NomClient;
            entityToUpdate.PrenomClient = entity.PrenomClient;
            entityToUpdate.MotDePasse= entity.MotDePasse;
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

        public User GetAuthUser(LoginModel user)
        {
            //return dbContext.Users.SingleOrDefault(x => x.EmailClient.ToUpper() == user.Email.ToUpper() && BCrypt.Net.BCrypt.Verify(user.Password, x.MotDePasse, false, BCrypt.Net.HashType.SHA256));
            // check if user email and password hash match with a record in the database
            var userFromDb = dbContext.Users.SingleOrDefault(x => x.EmailClient.ToUpper() == user.Email.ToUpper());
            if (userFromDb != null && BCrypt.Net.BCrypt.Verify(user.Password, userFromDb.MotDePasse, false, BCrypt.Net.HashType.SHA256))
            {
                // authentication successful so return user details without password
                return userFromDb;
            }
            return null;
        }

        public async Task<ActionResult<User>> FindByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(x => x.EmailClient == email);
        }
    }
}
