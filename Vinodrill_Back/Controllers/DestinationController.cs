using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers //PROBLEM 
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDataRepository<Destination> dataRepository;

        public DestinationController(IDataRepository<Destination> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Destination
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Destination>))]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Destination/GetDestinationById/1
        [HttpGet("GetDestinationById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Destination))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Destination>> GetDestinationById(int id)
        {
            var Destination = await dataRepository.GetById(id);

            if (Destination == null)
            {
                return NotFound();
            }

            return Destination;

        }

        ///PUT: api/Destination/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDestination(int id, Destination Destination)
        {

            if (id != Destination.IdDestination)
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
                await dataRepository.Update(userToUpdate.Value, Destination);
                return NoContent();
            }
        }


        // POST: api/Destination
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Destination))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Destination>> PostDestination(Destination Destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(Destination);

            return CreatedAtAction("GetDestinationById", new { id = Destination.IdDestination }, Destination);
        }

        // DELETE: api/Destination/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var Destination = await dataRepository.GetById(id);
            if (Destination == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(Destination.Value);

            return NoContent();
        }
    }
}
