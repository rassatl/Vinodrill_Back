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
    public class ThemeController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Theme> dataRepository;

        public ThemeController(IDataRepository<Theme> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Themes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Theme>))]
        public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
        {
            return await dataRepository.GetAll();
        }

    }
}
