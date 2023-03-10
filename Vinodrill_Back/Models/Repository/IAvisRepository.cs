using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IAvisRepository : IDataRepository<Avis>
    {
        Task<ActionResult<Avis>> GetByIdWithSejour(int id);
    }
}