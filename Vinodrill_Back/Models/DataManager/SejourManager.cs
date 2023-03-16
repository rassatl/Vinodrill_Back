using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.DataManager
{
    public class SejourManager : ISejourRepository
    {
        readonly VinodrillDBContext? dbContext;

        public SejourManager() { }

        public SejourManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Sejour entity)
        {
            await dbContext.Sejours.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Sejour entityToUpdate, Sejour entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;

            entityToUpdate.TitreSejour = entity.TitreSejour;
            entityToUpdate.DescriptionSejour = entity.DescriptionSejour;
            entityToUpdate.PrixSejour = entity.PrixSejour;
            entityToUpdate.NbJour = entity.NbJour;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Sejour entity)
        {
            dbContext.Sejours.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAll()
        {
            // get theme and destination
            return await dbContext.Sejours.ToListAsync();
        }

        public async Task<ActionResult<Sejour>> GetById(int id)
        {
            return await dbContext.Sejours.FirstOrDefaultAsync(a => a.IdSejour == id);
        }

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllWithParams(string? idsSejour = null, string? idsDestination = null, string? idsTheme = null, string? idsCatParticipant = null, int? limit = null, int? idSejour = null)
        {
            var sejours = dbContext.Sejours.AsQueryable();

            if(idsSejour is not null) {
                try {
                    var ids = idsSejour.Split(',').Select(int.Parse).ToArray();
                    sejours = dbContext.Sejours.Where(s => ids.Contains(s.IdSejour));
                } catch (Exception e) {
                    return null;
                }
            }

            if(idsDestination is not null) {
                try {
                    var ids = idsDestination.Split(',').Select(int.Parse).ToArray();
                    return await dbContext.Sejours
                        .Where(s => ids.Contains(s.IdDestination))
                        .Include(s => s.ThemeSejourNavigation)
                        .Include(s => s.DestinationSejourNavigation)
                        .ToListAsync();
                } catch (Exception e) {
                    return null;
                }
            }

            if(idsTheme is not null) {
                try {
                    var ids = idsTheme.Split(',').Select(int.Parse).ToArray();
                    sejours = sejours.Where(s => ids.Contains(s.IdTheme));
                } catch (Exception e) {
                    return null;
                }
            }

            if(idsCatParticipant is not null) {
                try {
                    // get all id from query parameter
                    var ids = idsCatParticipant.Split(',').Select(int.Parse).ToArray();

                    // get all id sejour from Participe table
                    var catParticipant = await dbContext.Participes
                        .Where(c => ids.Contains(c.IdCategorieParticipant))
                        .ToListAsync();

                    // get all id sejour from the previous query
                    var idsSejourFromQuery = catParticipant.Select(c => c.IdSejour).ToArray();

                    // get all sejour with the id sejour from the previous query
                    sejours
                        .Where(s => idsSejourFromQuery.Contains(s.IdSejour));
                } catch (Exception e) {
                    return null;
                }
            }


            if(idSejour is not null) {
                sejours = sejours.Where(s => s.IdSejour != idSejour);
            }

            if(limit is not null) {
                sejours = sejours.Take((int)limit);
            }

            return await sejours.ToListAsync();
        }

        public async Task<ActionResult<Sejour>> GetById(int id, bool includeVisite = false, bool includeDestination = false, bool includeTheme = false, bool includeCatParticipant = false, bool includaAvis = false, bool includeEtape = false, bool includeHebergement = false)
        {
            var sejour = dbContext.Sejours
                .Where(s => s.IdSejour == id)
                .AsQueryable();

            if(includeDestination) {
                sejour = sejour.Include(s => s.DestinationSejourNavigation);
            }

            if(includeTheme) {
                sejour = sejour.Include(s => s.ThemeSejourNavigation);
            }

            if(includeCatParticipant) {
                sejour = sejour.Include(s => s.ParticipeSejourNavigation)
                    .ThenInclude(p => p.CatParticipantParticipeNavigation);
            }

            if(includaAvis) {
                sejour = sejour.Include(s => s.AvisSejourNavigation);
            }

            if(includeEtape) {
                sejour = sejour.Include(s => s.EtapeSejourNavigation);
            }

            if(includeHebergement) {
                sejour = sejour.Include(s => s.EtapeSejourNavigation).ThenInclude(e => e.HebergementEtapeNavigation);
            }

            return await sejour.FirstOrDefaultAsync();
        }
    }
}
