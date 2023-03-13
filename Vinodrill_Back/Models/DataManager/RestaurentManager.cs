using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
        public class RestaurentManager : IDataRepository<Restaurant>
        {
            readonly VinodrillDBContext? dbContext;

            public RestaurentManager() { }

            public RestaurentManager(VinodrillDBContext context) { dbContext = context; }

            public async Task Add(Restaurant entity)
            {
                await dbContext.Restaurant.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task Update(Restaurant entityToUpdate, Restaurant entity)
            {
                dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                entityToUpdate.IdPartenaire = entity.IdPartenaire;
                entityToUpdate.NomPartenaire = entity.NomPartenaire;
                entityToUpdate.PhotoPartenaire = entity.PhotoPartenaire;
                entityToUpdate.RuePartenaire = entity.RuePartenaire;
                entityToUpdate.Contact = entity.Contact;
            entityToUpdate.SpecialiteRestaurant = entity.SpecialiteRestaurant;
            entityToUpdate.CpPartenaire = entity.CpPartenaire;
            entityToUpdate.VillePartenaire = entity.VillePartenaire;


            await dbContext.SaveChangesAsync();
            }

            public async Task Delete(Restaurant entity)
            {
                dbContext.Restaurant.Remove(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task<ActionResult<IEnumerable<Restaurant>>> GetAll()
            {
                return await dbContext.Restaurant.ToListAsync();
            }

            public async Task<ActionResult<Restaurant>> GetById(int id)
            {
                return await dbContext.Restaurant.FirstOrDefaultAsync(a => a.IdPartenaire == id);
            }
        }
    }
