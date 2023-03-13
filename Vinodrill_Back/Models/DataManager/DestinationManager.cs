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

            public async Task Add(Destination entity)
            {
                await dbContext.Destination.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task Update(Destination entityToUpdate, Destination entity)
            {
                dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                entityToUpdate.IdDestination = entity.IdDestination;
                entityToUpdate.LibelleDestination = entity.LibelleDestination;
                entityToUpdate.DescriptionDestination = entity.DescriptionDestination;

                await dbContext.SaveChangesAsync();
            }

            public async Task Delete(Destination entity)
            {
                dbContext.Destination.Remove(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task<ActionResult<IEnumerable<Destination>>> GetAll()
            {
                return await dbContext.Destination.ToListAsync();
            }

            public async Task<ActionResult<Destination>> GetById(int id)
            {
                return await dbContext.Destination.FirstOrDefaultAsync(a => a.IdDestination == id);
            }
        }
    }
