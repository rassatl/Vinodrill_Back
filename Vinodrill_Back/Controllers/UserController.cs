using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.Auth;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository dataRepository;

        public UserController(IUserRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        [HttpGet("GetUserById/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id, bool withAdresse = false)
        {
            var client = await dataRepository.GetById(id, withAdresse);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, User client)
        {

            if (id != client.IdClient)
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
                await dataRepository.Update(userToUpdate.Value, client);
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> PostUser(User client)
        {
            await dataRepository.Add(client);
            return CreatedAtAction(nameof(GetUserById), new { id = client.IdClient }, client);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = await dataRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            await dataRepository.Delete(client.Value);
            return NoContent();
        }

        [HttpGet]
        [Route("GetUserData")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserData( [FromQuery] int id)
        {
            var user = await dataRepository.GetAllUserData(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult GetAdminData()
        {
            return Ok("This is a response from Admin method");
        }

        [HttpGet]
        [Route("CheckToken")]
        public IActionResult CheckToken(string token)
        {
            return Ok(new { valid = CheckExiredJwt(token) });
        }

        private static long GetTokenExpirationTime(string token)
        {
            DateTime dateTime = DateTime.Now.AddMinutes(-1);
            var ticks = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
                ticks = long.Parse(tokenExp);
            } catch(Exception ex)
            {

            }
            return ticks;
        }

        private bool CheckExiredJwt(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            var now = DateTime.Now.ToUniversalTime();

            var valid = tokenDate >= now;

            return valid;        
        }
    }
}
