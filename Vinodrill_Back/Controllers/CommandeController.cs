using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController: ControllerBase
    {
        private readonly IcommandeRepository dataRepository;

        public CommandeController(IcommandeRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Commandes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Commande>))]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Commandes/GetCommandeById/5
        [HttpGet("GetCommandeById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Commande))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commande>> GetCommandeById(int id)
        {
            var Commande = await dataRepository.GetById(id);

            if (Commande == null)
            {
                return NotFound();
            }

            return Commande;
        }
    }
}
