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
        private readonly IDataRepository<CatParticipant> dataRepository;
        public CatparticipantController(IDataRepository<CatParticipant> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CatParticipant
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CatParticipant>))]
        public async Task<ActionResult<IEnumerable<CatParticipant>>> GetAdresses()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/CatParticipant/GetCatParticipantById/5
        [HttpGet("GetCatParticipanteById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatParticipant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CatParticipant>> GetCatParticipantById(int id)
        {
            return StatusCode(StatusCodes.Status405MethodNotAllowed);
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
        // POST: api/CatParticipants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatParticipant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatParticipant>> PostAdresse(CatParticipant catparticipant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(catparticipant);

            return CreatedAtAction("GetCatParticipantById", new { id = catparticipant.IdCategorieParticipant }, catparticipant);
        }

        // DELETE: api/CatParticipants/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var catparticipant = await dataRepository.GetById(id);
            if (catparticipant == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(catparticipant.Value);

            return NoContent();
        }
    }
}
