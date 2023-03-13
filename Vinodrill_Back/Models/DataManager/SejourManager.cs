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

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificDestination(string idsDestination)
        {
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

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificTheme(string idsTheme)
        {
            try {
                var ids = idsTheme.Split(',').Select(int.Parse).ToArray();
                return await dbContext.Sejours
                    .Where(s => ids.Contains(s.IdTheme))
                    .ToListAsync();
            } catch (Exception e) {
                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificCatParticipant(string idsCatParticipant)
        {
            try {
                // get all id from query parameter
                var ids = idsCatParticipant.Split(',').Select(int.Parse).ToArray();

                // get all id sejour from Participe table
                var catParticipant = await dbContext.Participes
                    .Where(c => ids.Contains(c.IdCategorieParticipant))
                    .ToListAsync();

                // get all id sejour from the previous query
                var idsSejour = catParticipant.Select(c => c.IdSejour).ToArray();

                // get all sejour with the id sejour from the previous query
                return await dbContext.Sejours
                    .Where(s => idsSejour.Contains(s.IdSejour))
                    .ToListAsync();

            } catch (Exception e) {
                return null;
            }
        }

        public Task<ActionResult<IEnumerable<Sejour>>> GetAllExceptSpecificSejour(int idSejour)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Sejour>>> GetAllSetLimit(int limit)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Sejour>>> GetMultipleSejour(string idsSejour)
        {
            throw new NotImplementedException();
        }
    }
}
