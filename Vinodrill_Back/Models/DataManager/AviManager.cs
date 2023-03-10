using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Vinodrill_Back.Models.DataManager
{
    public class AviManager : IDataRepository<Avis>
    {
        readonly VinodrillDBContext? dbContext;

        public AviManager() { }

        public AviManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Avis entity)
        {
            await dbContext.Avis.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
            
        public async Task Update(Avis entityToUpdate, Avis entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdAvis = entity.IdAvis;
            entityToUpdate.IdClient = entity.IdClient;
            entityToUpdate.IdSejour = entity.IdSejour;
            entityToUpdate.AvisSignale = entity.AvisSignale;
            entityToUpdate.Commentaire = entity.Commentaire;
            entityToUpdate.Note = entity.Note;
            entityToUpdate.TitreAvis = entity.TitreAvis;
            entityToUpdate.DateAvis = entity.DateAvis;
            entityToUpdate.TypeSignalement = entity.TypeSignalement;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Avis entity)
        {
            dbContext.Avis.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Avis>>> GetAll()
        {
            return await dbContext.Avis.ToListAsync();
        }

        public async Task<ActionResult<Avis>> GetById(int id)
        {
            Avis response = await dbContext.Avis.FirstOrDefaultAsync(a => a.IdAvis == id);

            return response;
        }

        public async Task<ActionResult<Avis>> GetByIdWithSejour(int id)
        {
            Avis response = await dbContext.Avis.Include(a => a.SejourAvisNavigation).FirstOrDefaultAsync(a => a.IdAvis == id);

            return response;
        }
    }
}
