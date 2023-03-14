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
    public class HebergementController : ControllerBase
    {
        private readonly IDataRepository<Hebergement> dataRepository;

        public HebergementController(IDataRepository<Hebergement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Hebergement
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hebergement>))]
        public async Task<ActionResult<IEnumerable<Hebergement>>> GetHebergement()
        {
            return await dataRepository.GetAll();
        }
        // POST: api/Hebergement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hebergement))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hebergement>> PostAdresse(Hebergement heb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(heb);

            return CreatedAtAction("GetCatParticipantById", new { id = heb.IdHebergement }, heb);
        }
    }
}
