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
        private readonly IHebergementRepository dataRepository;

        public HebergementController(IHebergementRepository dataRepo)
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

        // GET: api/Hebergement
        [HttpGet("{idHotel}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hebergement>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Hebergement>>> GetHebergementByHotel(int? idHotel)
        {
            return await dataRepository.GetAllSpecificWithHotel(idHotel);
        }

        // // POST: api/Hebergement
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hebergement))]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<Hebergement>> PostAdresse(Hebergement hebergement, Hotel hotel)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     await dataRepository.Add(hebergement, hotel);

        //     return CreatedAtAction("GetHebergement", new { id = hebergement.IdHebergement }, hebergement);
        // }

        // GET: api/Activites/GetVisiteById/5
        [HttpGet("GetHebergementById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hebergement))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hebergement>> GetHebergementById(int id)
        {
            var hebergement = await dataRepository.GetById(id);

            if (hebergement == null)
            {
                return NotFound();
            }

            return hebergement;

        }
    }
}
