using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IHebergementRepository : IDataRepository<Hebergement>
    {
        Task Add(Hebergement entity, Hotel hotel);
        Task<ActionResult<IEnumerable<Hebergement>>> GetAllSpecificWithHotel(int? idHotel);

    }
}
