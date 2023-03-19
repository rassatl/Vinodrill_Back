using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.Repository;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonReductionController : ControllerBase
    {
        private readonly IBonreductionRepository dataRepository;
        public BonReductionController(IBonreductionRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        [HttpGet("check")]
        [Authorize]
        public async Task<IActionResult> Check(string code)
        {
            var bonReduction = await dataRepository.check(code);

            if (bonReduction.Value == null)
            {
                return NotFound();
            }

            var montant = await dataRepository.getAmount(bonReduction.Value);

            return Ok(new { amount = montant.Value });
        }
    }
}
