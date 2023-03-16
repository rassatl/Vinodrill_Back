using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{

        public class EffectueManager : IDataRepository<Effectue>
        {
            readonly VinodrillDBContext? dbContext;

            public EffectueManager() { }

            public EffectueManager(VinodrillDBContext context) { dbContext = context; }

            public async Task Add(Effectue entity)
            {
                await dbContext.Effectues.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task Update(Effectue entityToUpdate, Effectue entity)
            {
                dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                entityToUpdate.IdActivite = entity.IdActivite;
                entityToUpdate.IdEtape = entity.IdEtape;

                await dbContext.SaveChangesAsync();
            }

            public async Task Delete(Effectue entity)
            {
                dbContext.Effectues.Remove(entity);
                await dbContext.SaveChangesAsync();
            }

            public async Task<ActionResult<IEnumerable<Effectue>>> GetAll()
            {
                return await dbContext.Effectues.ToListAsync();
            }

            public async Task<ActionResult<Effectue>> GetById(int id)
            {
                return await dbContext.Effectues.FirstOrDefaultAsync(a => a.IdEtape == id);
            }
        }
    }
    
