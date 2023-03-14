using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IBonCommandeRepository : IDataRepository<BonCommande>
    {
        Task<ActionResult<BonCommande>> GetByRefCommande(int refcommande);
    }
}
