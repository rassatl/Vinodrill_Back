using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartenaireController : ControllerBase
    {
        private readonly IDataRepository<Partenaire> dataRepository;

        public PartenaireController(IDataRepository<Partenaire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Partenaires
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Partenaire>))]
        public async Task<ActionResult<IEnumerable<Partenaire>>> GetPartenaires()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Partenaire/GetPartenaireById/1
        [HttpGet("GetPartenaireById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Partenaire))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Partenaire>> GetPartenaireById(int id)
        {
            var Activite = await dataRepository.GetById(id);

            if (Activite == null)
            {
                return NotFound();
            }

            return Activite;

            /*return StatusCode(StatusCodes.Status405MethodNotAllowed);*/
        }
    }
}
