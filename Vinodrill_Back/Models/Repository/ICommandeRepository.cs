using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface IcommandeRepository : IDataRepository<Commande>
    {
        new Task<int> Add(Commande entity);
        Task<ActionResult<Commande>> GetCommandeById(int id);
    }
}
