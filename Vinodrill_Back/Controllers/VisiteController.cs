using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiteController: ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Visite> dataRepository;

        public VisiteController(IDataRepository<Visite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Visites
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Visite>))]
        public async Task<ActionResult<IEnumerable<Visite>>> GetVisites()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Activites/GetVisiteById/5
        [HttpGet("GetVisiteById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Visite))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Visite>> GetVisiteById(int id)
        {
            var visite = await dataRepository.GetById(id);

            if (visite == null)
            {
                return NotFound();
            }

            return visite;

        }
    }
}
