using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonCommandeController : ControllerBase  // des bails a ajouter
    {
        private readonly VinodrillDBContext _context;

        public BonCommandeController(VinodrillDBContext context)
        {
            _context = context;
        }


        // GET: api/BonCommande/5
        [HttpGet("{refcommande}")]
        public async Task<ActionResult<BonCommande>> GetBonCommande(int refcommande)
        {
            var bonCommande = await _context.BonCommandes.FindAsync(refcommande);

            if (bonCommande == null)
            {
                return NotFound();
            }

            return bonCommande;
        }
    }
}
