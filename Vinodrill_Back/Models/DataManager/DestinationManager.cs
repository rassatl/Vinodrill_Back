using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class DestinationManager : IDataRepository<Destination>
    {
        
            readonly VinodrillDBContext? dbContext;

            public DestinationManager() { }

            public DestinationManager(VinodrillDBContext context) { dbContext = context; }

        public Task Add(Destination entity)
        {
            return null;
        }

        public Task Delete(Destination entity)
        {
            return null;
        }

        public async Task<ActionResult<IEnumerable<Destination>>> GetAll()
            {
                return await dbContext.Destination.ToListAsync();
            }

        public Task<ActionResult<Destination>> GetById(int id)
        {
            return null;
        }

        public Task Update(Destination entityToUpdate, Destination entity)
        {
            return null;
        }
    }
    }
