using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Vinodrill_Back.Models.DataManager
{
    public class ReponseAvisManager : IDataRepository<ReponseAvis>
    {
        readonly VinodrillDBContext? dbContext;

        public ReponseAvisManager() { }

        public ReponseAvisManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(ReponseAvis entity)
        {
            await dbContext.ReponseAvis.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task Delete(ReponseAvis entity)
        {
            return null;
        }

        public Task<ActionResult<IEnumerable<ReponseAvis>>> GetAll()
        {
            return null;
        }

        public async Task<ActionResult<ReponseAvis>> GetById(int id)
        {
            return await dbContext.ReponseAvis.FirstOrDefaultAsync(a => a.IdReponseAvis == id);
        }

        public async Task Update(ReponseAvis entityToUpdate, ReponseAvis entity)
        {
            return;
        }

        

        
    }
}
