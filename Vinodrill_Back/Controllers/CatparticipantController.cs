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
    public class CatparticipantController : ControllerBase
    {
        private readonly VinodrillDBContext _context;

        public CatparticipantController(VinodrillDBContext context)
        {
            _context = context;
        }

        // GET: api/CatParticipant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatParticipant>>> GetCatParticipant()
        {
            return await _context.Catparticipants.ToListAsync();
        }

        // GET: api/CatParticipant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatParticipant>> GetCatParticipant(int id)
        {
            var avis = await _context.Catparticipants.FindAsync(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        //PUT: api/Catparticipants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCatparticipants(int id, CatParticipant catparticipant)
        {

            if (id != catparticipant.IdCategorieParticipant)
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
                await dataRepository.Update(userToUpdate.Value, catparticipant);
                return NoContent();
            }
        }
        // POST: api/CatParticipant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avis>> PostCatParticipant(CatParticipant catparticipant)
        {
            _context.Catparticipants.Add(catparticipant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatParticipant", new { id = catparticipant.IdCategorieParticipant }, catparticipant);
        }

        // DELETE: api/CatParticipant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatParticipant(int id)
        {
            var catparticipant = await _context.Catparticipants.FindAsync(id);
            if (catparticipant == null)
            {
                return NotFound();
            }

            _context.Catparticipants.Remove(catparticipant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
