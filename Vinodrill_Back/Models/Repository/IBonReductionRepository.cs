using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IBonreductionRepository : IDataRepository<BonReduction>
    {
        Task<ActionResult<BonReduction>> GetByCode(string codeCoupon);
    }
}