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
    public class SocieteController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Societe> dataRepository;

        public SocieteController(IDataRepository<Societe> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Societes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Societe>))]
        public async Task<ActionResult<IEnumerable<Societe>>> GetSocietes()
        {
            return await dataRepository.GetAll();
        }
    }
}