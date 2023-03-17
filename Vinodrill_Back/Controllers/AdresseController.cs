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
    public class AdresseController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Adresse> dataRepository;

        public AdresseController(IDataRepository<Adresse> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Adresse
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Adresse>))]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Adresse/GetAdresseById/5
        [HttpGet("GetAdresseById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Adresse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseById(int id)
        {
            var hotel = await dataRepository.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        //PUT: api/Adresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdresse(int id, Adresse Adresse)
        {

            if (id != Adresse.IdAdresse)
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
                await dataRepository.Update(userToUpdate.Value, Adresse);
                return NoContent();
            }
        }

        // POST: api/Adresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Adresse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse Adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(Adresse);

            return CreatedAtAction("GetAdresseById", new { id = Adresse.IdAdresse }, Adresse);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var Adresse = await dataRepository.GetById(id);
            if (Adresse == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(Adresse.Value);

            return NoContent();
        }

    }
}