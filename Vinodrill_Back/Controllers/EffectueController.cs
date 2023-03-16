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
    public class EffectueController : ControllerBase
    {
        private readonly IDataRepository<Effectue> dataRepository;

        public EffectueController(IDataRepository<Effectue> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Effectue
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Effectue>))]
        public async Task<ActionResult<IEnumerable<Effectue>>> GetEffectue()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Effectue/GetEffectueById/1
        [HttpGet("GetEffectueById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Effectue))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Effectue>> GetEffectueById(int id)
        {
            var Effectue = await dataRepository.GetById(id);

            if (Effectue == null)
            {
                return NotFound();
            }

            return Effectue;

        }

        ///PUT: api/Effectue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutEffectue(int id, Effectue Effectue)
        {

            if (id != Effectue.IdEtape)
            {
                return BadRequest();
            }

            var userToUpdate = await dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.Update(userToUpdate.Value, Effectue);
                return NoContent();
            }
        }


        // POST: api/Effectue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Effectue))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Effectue>> PostEffectue(Effectue Effectue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(Effectue);

            return CreatedAtAction("GetEffectueById", new { id = Effectue.IdEtape }, Effectue);
        }

        // DELETE: api/Effectue/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEffectue(int id)
        {
            var Effectue = await dataRepository.GetById(id);
            if (Effectue == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(Effectue.Value);

            return NoContent();
        }
    }
}
