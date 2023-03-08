using Microsoft.AspNetCore.Mvc;

namespace Vinodrill_Back.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(int id);
        //Task<ActionResult<TEntity>> GetByString(string str);
        Task Add(TEntity entity);
        Task Update(TEntity entityToUpdate, TEntity entity);
        Task Delete(TEntity entity);
    }
}
