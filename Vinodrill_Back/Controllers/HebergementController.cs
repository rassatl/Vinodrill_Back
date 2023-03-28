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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hebergement))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hebergement>> Post(RequestBodyHebergement request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hotel hotel = new Hotel
            {
                NomPartenaire = request.NomPartenaire,
                RuePartenaire = request.RuePartenaire,
                CpPartenaire = request.CpPartenaire,
                VillePartenaire = request.VillePartenaire,
                PhotoPartenaire = request.PhotoPartenaire,
                EmailPartenaire = request.EmailPartenaire,
                Contact = request.Contact,
                DetailPartenaire = request.DetailPartenaire,
                NbEtoileHotel = request.NbEtoileHotel,
            };

            Hebergement hebergement = new Hebergement
            {
                LibelleHebergement = request.LibelleHebergement,
                DescriptionHebergement = request.DescriptionHebergement,
                NbChambre = request.NbChambre,
                HoraireHebergement = TimeOnly.FromDateTime(DateTime.Parse( request.HoraireHebergement))
            };

            await dataRepository.Add(hebergement, hotel);

            return CreatedAtAction("GetHebergementById", new { id = hebergement.IdHebergement }, hebergement);
        }

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

    public class RequestBodyHebergement
    {
        /*public int IdPartenaire {get; set;}
        public int IdHebergement {get; set;}*/
        public string LibelleHebergement { get; set; }
        public string DescriptionHebergement { get; set; }
        public int NbChambre { get; set; }
        public string HoraireHebergement { get; set; }
        
        public string NomPartenaire { get; set; }
        public string RuePartenaire { get; set; }
        public string CpPartenaire { get; set; }
        public string VillePartenaire { get; set; }
        public string? PhotoPartenaire { get; set; }
        public string EmailPartenaire { get; set; }
        public string Contact { get; set; }
        public string DetailPartenaire { get; set; }
        public int NbEtoileHotel { get; set; }
    }
}
