using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.Auth;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {
        readonly VinodrillDBContext? dbContext;

        public ReservationManager() { }

        public ReservationManager(VinodrillDBContext context) { dbContext = context; }
        public async Task Add(Reservation entity)
        {
            await dbContext.Reservations.AddAsync(entity);
            await dbContext.SaveChangesAsync(); 
        }

        public Task Delete(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Reservation>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Reservation entityToUpdate, Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}