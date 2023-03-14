using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IHebergementRepository : IDataRepository<Hebergement>
    {
        Task<ActionResult<Hebergement>> GetAllSpecificWithEtapeAndHotel(string idsEtape = "notImplemented", int idHotel = 0);

    }
}
