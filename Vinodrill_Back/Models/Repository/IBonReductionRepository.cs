using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IBonreductionRepository : IDataRepository<BonReduction>
    {
        Task<ActionResult<BonReduction>> check(string codeCoupon);
        Task<ActionResult<BonReduction>> getByCode(string codeCoupon);
        Task<ActionResult<decimal>> getAmount(BonReduction bonReduction);
    }
}