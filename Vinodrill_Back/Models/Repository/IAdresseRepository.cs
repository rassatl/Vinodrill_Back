using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IAdresseRepository : IDataRepository<Adresse>
    {
        Task<ActionResult<Adresse>> GetById(int id);
    }
}
