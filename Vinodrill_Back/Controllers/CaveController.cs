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
    public class CaveController : ControllerBase
    {
        private readonly IDataRepository<Cave> dataRepository;

        public CaveController(IDataRepository<Cave> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Cave
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Cave>))]
        public async Task<ActionResult<IEnumerable<Cave>>> GetCave()
        {
            return await dataRepository.GetAll();
        }
    }
}
