using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipeController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Participe> dataRepository;

        public ParticipeController(IDataRepository<Participe> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Participes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Participe>))]
        public async Task<ActionResult<IEnumerable<Participe>>> GetParticipes()
        {
            return await dataRepository.GetAll();
        }
    }
}
