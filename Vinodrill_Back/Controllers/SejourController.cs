using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.Auth;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SejourController : ControllerBase
    {
        private readonly ISejourRepository dataRepository;

        public SejourController(ISejourRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Avis
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Sejour>))]
        public async Task<ActionResult<IEnumerable<Sejour>>> GetSejours([FromQuery] string? idstheme = null, [FromQuery] string? idsSejour = null, [FromQuery] string? idsDestination = null,[FromQuery]  string? idsCatParticipant = null, [FromQuery] int? limit = null, [FromQuery] int? idSejour = null)
        {
            return await dataRepository.GetAllWithParams(idsSejour, idsDestination, idstheme, idsCatParticipant, limit, idSejour);
        }

        // GET: api/Avis/GetAvisById/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Sejour))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sejour>> GetSejourById(int id, [FromQuery] bool includeVisite = false, [FromQuery] bool includeDestination = false, [FromQuery] bool includeTheme = false, [FromQuery] bool includeCatParticipant = false, [FromQuery] bool includaAvis = false, [FromQuery] bool includeEtape = false, [FromQuery] bool includeHebergement = false)
        {
            // initialisation de la variable qui va contenir l'avis à retourner, null par défaut, de type inconu

            var sejour = await dataRepository.GetById(id, includeVisite, includeDestination, includeTheme, includeCatParticipant, includaAvis, includeEtape, includeHebergement);

            if (sejour == null)
            {
                return NotFound();
            }

            return sejour;

            // return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        //PUT: api/Sejour/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutSejour(int id, Sejour sejour)
        {

            if (id != sejour.IdSejour)
            {
                return BadRequest();
            }

            var sejourToUpdate = await dataRepository.GetById(id);
            if (sejourToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.Update(sejourToUpdate.Value, sejour);
                return NoContent();
            }
        }

        // POST: api/Avis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Sejour))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<Sejour>> PostSejour(Sejour sejour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(sejour);

            return CreatedAtAction("GetAvisById", new { id = sejour.IdSejour }, sejour);
        }

        // DELETE: api/Avis/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> DeleteAvis(int id)
        {
            var sejour = await dataRepository.GetById(id);
            if (sejour == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(sejour.Value);

            return NoContent();
        }
    }
}
