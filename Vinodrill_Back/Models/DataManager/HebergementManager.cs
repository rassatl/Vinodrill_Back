using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class HebergementManager : IHebergementRepository
    {
        readonly VinodrillDBContext? dbContext;

        public HebergementManager() { }

        public HebergementManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Hebergement entity)
        {
            await dbContext.Hebergements.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(Hebergement entity, Hotel hotel)
        {
            
            Partenaire newPartenaire = new Partenaire{
                NomPartenaire = hotel.NomPartenaire,
                RuePartenaire = hotel.RuePartenaire,
                CpPartenaire = hotel.CpPartenaire,
                VillePartenaire = hotel.VillePartenaire,
                PhotoPartenaire = hotel.PhotoPartenaire,
                EmailPartenaire = hotel.EmailPartenaire,
                Contact = hotel.Contact,
                DetailPartenaire = hotel.DetailPartenaire
            };

            

            dbContext.Partenaires.Add(newPartenaire);
            await dbContext.SaveChangesAsync();

            int idPartenaire = dbContext.Partenaires.OrderByDescending(p => p.IdPartenaire).First().IdPartenaire;

            hotel.IdPartenaire= idPartenaire;
            dbContext.Hotels.Add(hotel);

            entity.IdPartenaire= idPartenaire;
            await dbContext.Hebergements.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task Delete(Hebergement entity)
        {
            return null;
        }

        public async Task<ActionResult<IEnumerable<Hebergement>>> GetAll()
        {
            return await dbContext.Hebergements.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Hebergement>>> GetAllSpecificWithHotel(int? idHotel = null)
        {
            var hebergements = dbContext.Hebergements.AsQueryable();

            if(idHotel is not null)
            {
                try
                {
                    hebergements = hebergements.Where(h => h.IdPartenaire == idHotel);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return await hebergements.ToListAsync();

        }

        public async Task<ActionResult<Hebergement>> GetById(int id)
        {
            return await dbContext.Hebergements.FirstOrDefaultAsync(a => a.IdHebergement == id);
        }

        public Task Update(Hebergement entityToUpdate, Hebergement entity)
        {
            return null;
        }
    }
}
