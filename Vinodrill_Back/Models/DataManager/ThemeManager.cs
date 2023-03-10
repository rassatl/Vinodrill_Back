using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Models.DataManager
{
    public class ThemeManager : IDataRepository<Theme>
    {
        readonly VinodrillDBContext? dbContext;

        public ThemeManager() { }

        public ThemeManager(VinodrillDBContext context) { dbContext = context; }

        public async Task Add(Theme entity)
        {
            await dbContext.Themes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Theme entityToUpdate, Theme entity)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            entityToUpdate.IdTheme = entity.IdTheme;
            entityToUpdate.LibelleTheme = entity.LibelleTheme;
            entityToUpdate.ImgThemePage = entity.ImgThemePage;
            entityToUpdate.ContenuThemePage = entity.ContenuThemePage;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Theme entity)
        {
            dbContext.Themes.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Theme>>> GetAll()
        {
            return await dbContext.Themes.ToListAsync();
        }

        public async Task<ActionResult<Theme>> GetById(int id)
        {
            return await dbContext.Themes.FirstOrDefaultAsync(a => a.IdTheme == id);
        }
    }
}
