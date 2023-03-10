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
    public class TypeVisiteController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<TypeVisite> dataRepository;

        public TypeVisiteController(IDataRepository<TypeVisite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/TypeVisites
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TypeVisite>))]
        public async Task<ActionResult<IEnumerable<TypeVisite>>> GetTypeVisites()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Activites/GetTypeVisiteById/5
        [HttpGet("GetTypeVisiteById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TypeVisite))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeVisite>> GetTypeVisiteById(int id)
        {
            var typeVisite = await dataRepository.GetById(id);

            if (typeVisite == null)
            {
                return NotFound();
            }

            return typeVisite;

        }
    }
}
