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

        ///PUT: api/Partenaire/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPartenaire(int id, Partenaire Partenaire)
        {

            if (id != Partenaire.IdPartenaire)
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
                await dataRepository.Update(userToUpdate.Value, Partenaire);
                return NoContent();
            }
        }


        // POST: api/Partenaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Partenaire))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Partenaire>> PostPartenaire(Partenaire Partenaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(Partenaire);

            return CreatedAtAction("GetPartenaireById", new { id = Partenaire.IdPartenaire }, Partenaire);
        }

        // DELETE: api/Partenaires/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePartenaire(int id)
        {
            var Partenaire = await dataRepository.GetById(id);
            if (Partenaire == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(Partenaire.Value);

            return NoContent();
        }
    }
}
