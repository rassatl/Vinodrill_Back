using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class CaveManager : IDataRepository<Cave>
    {
        readonly VinodrillDBContext? dbContext;

        public CaveManager() { }

        public CaveManager(VinodrillDBContext context) { dbContext = context; }

        public Task Add(Cave entity)
        {
            return null;
        }

        public Task Delete(Cave entity)
        {
            return null;
        }

        public async Task<ActionResult<IEnumerable<Cave>>> GetAll()
        {
            return await dbContext.Caves.ToListAsync();
        }

        public Task<ActionResult<Cave>> GetById(int id)
        {
            return null;
        }

        public Task Update(Cave entityToUpdate, Cave entity)
        {
            return null;
        }
    }
}
