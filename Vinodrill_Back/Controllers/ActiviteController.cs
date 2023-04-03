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
    public class ActiviteController : ControllerBase
    {
        //private readonly FilmRatingDBContexts dataRepository;
        private readonly IDataRepository<Activite> dataRepository;

        public ActiviteController(IDataRepository<Activite> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Activites
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Activite>))]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Activites/GetActiviteById/5
        [HttpGet("GetActiviteById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Activite))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            //var Activite = await dataRepository.GetById(id);

            //if (Activite == null)
            //{
            //    return NotFound();
            //}

            //return Activite;

            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        //PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActivite(int id, Activite Activite)
        {

            if (id != Activite.IdActivite)
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
                await dataRepository.Update(userToUpdate.Value, Activite);
                return NoContent();
            }
        }

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Activite))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Activite>> PostActivite(RequestBodyActivite request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activite activite = request.ToActivite();

            await dataRepository.Add(activite);

            return CreatedAtAction("GetActiviteById", new { id = activite.IdActivite }, activite);
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var Activite = await dataRepository.GetById(id);
            if (Activite == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(Activite.Value);

            return NoContent();
        }

    }

    public class RequestBodyActivite
    {
        public int? IdActivite { get; set; }
        public int IdPartenaire { get; set; }
        public string LibelleActivite { get; set; }
        public string DescriptionActivite { get; set; }
        public string RueRdv { get; set; }
        public string CpRdv { get; set; }
        public string VilleRdv { get; set; }
        public string HoraireActivite { get; set; }

        public Activite ToActivite()
        {
            Activite activite = new Activite
            {
                IdPartenaire = this.IdPartenaire,
                LibelleActivite = this.LibelleActivite,
                DescriptionActivite = this.DescriptionActivite,
                RueRdv = this.RueRdv,
                CpRdv = this.CpRdv,
                VilleRdv = this.VilleRdv,
                HoraireActivite = TimeOnly.FromDateTime(DateTime.Parse(this.HoraireActivite))
            };

            return activite;
        }
    }
}