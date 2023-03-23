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
    public class ReponseAvisController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<ReponseAvis> dataRepository;

        public ReponseAvisController(IDataRepository<ReponseAvis> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Reponse/GetReponseById/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReponseAvis))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReponseAvis>> GetReponseById(int id)
        {

            var reponse = await dataRepository.GetById(id);

            if (reponse.Value == null)
            {
                return NotFound();
            }

            return reponse;

        }


        // POST: api/Reponse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReponseAvis))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseAvis>> PostActivite(ReponseAvis reponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.Add(reponse);

            return CreatedAtAction("GetReponseById", new { id = reponse.IdReponseAvis }, reponse);
        }

        

    }
}