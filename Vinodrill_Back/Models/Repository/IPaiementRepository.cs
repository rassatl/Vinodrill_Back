using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IPaiementRepository : IDataRepository<Paiement>
    {
        new Task<ActionResult<Paiement>> Add(Paiement entity);
    }
}