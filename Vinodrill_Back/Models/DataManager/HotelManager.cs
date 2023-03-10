using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class HotelManager : IDataRepository<Hotel>
    {
        readonly VinodrillDBContext? dbContext;

        public HotelManager() { }

        public HotelManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Hotel entity)
        {
            await dbContext.Hotels.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Hotel entityToUpdate, Hotel entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdPartenaire = entity.IdPartenaire;
            entityToUpdate.NbEtoileHotel = entity.NbEtoileHotel;
            entityToUpdate.NomPartenaire = entity.NomPartenaire;
            entityToUpdate.RuePartenaire = entity.RuePartenaire;
            entityToUpdate.CpPartenaire = entity.CpPartenaire;
            entityToUpdate.VillePartenaire = entity.VillePartenaire;
            entityToUpdate.PhotoPartenaire = entity.PhotoPartenaire;
            entityToUpdate.EmailPartenaire = entity.EmailPartenaire;
            entityToUpdate.Contact = entity.Contact;
            entityToUpdate.DetailPartenaire = entity.DetailPartenaire;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Hotel entity)
        {
            dbContext.Hotels.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            return await dbContext.Hotels.ToListAsync();
        }

        public async Task<ActionResult<Hotel>> GetById(int id)
        {
            return await dbContext.Hotels.FirstOrDefaultAsync(a => a.IdPartenaire == id);
        }
    }
}
