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
    public class HotelController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Hotel> dataRepository;

        public HotelController(IDataRepository<Hotel> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Hotels
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hotel>))]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Hotels/GetHotelById/5
        [HttpGet("GetHotelById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var hotel = await dataRepository.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }
    }
}