using Vinodrill_Back.Models.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Vinodrill_Back.Models.Repository;
using Vinodrill_Back.Models.Auth;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis;
using Google.Apis.Services;
using Stripe;
using static Google.Apis.Requests.BatchRequest;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository dataRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IUserRepository dataRepo, IConfiguration configuration)
        {
            dataRepository = dataRepo;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IActionResult response = Unauthorized();
            User user = AuthenticateUser(model);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        /*[AllowAnonymous]
        [Route("google-login")]
        public async Task<IActionResult> GoogleLogin(CancellationToken cancelToken)
        {
            IActionResult response = Unauthorized();

            var result = await new AuthorizationCodeMvcApp(this,
                            new GoogleAuth()).AuthorizeAsync(cancelToken);

            if (result.Credential == null)
                return new RedirectResult(result.RedirectUri);

            var plusService = new PlusService(new BaseClientService.Initializer
            {
                HttpClientInitializer = result.Credential,
                ApplicationName = "MyApp"
            });

            //get the user basic information
            Person me = plusService.People.Get("me").Execute();

            //check if the user is exists in our database
            var user = await dataRepository.GetByEmail(me.Email);

            if (user.Value != null)
            {
                var tokenString = GenerateJwtToken(user.Value);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
        }*/

        private User AuthenticateUser(LoginModel user)
        {
            return dataRepository.GetAuthUser(user);
        }

        private string GenerateJwtToken(User userInfo)
        {
            var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.EmailClient),
                new Claim("email", userInfo.EmailClient.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var userExists = await dataRepository.FindByEmail(model.Email);
            if (userExists.Result != null)
                return StatusCode(StatusCodes.Status409Conflict, new { Status = "Error", Message = "User already exists!" });

            if (!Regex.IsMatch(model.Password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$"))
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "Password is not valid!" });

            if (model.DateOfBirth.AddYears(18) > DateTime.Now)
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "You must be 18 years old to register!" });

            if(model.Gender.ToUpper() != "M" && model.Gender.ToUpper() != "F")
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = $"'{model.Gender}' is not a valid value for gender. The only valid values are 'M' for male and 'F' for female" });

            User user = new()
            {
                EmailClient = model.Email,
                PrenomClient = model.FirstName,
                NomClient = model.LastName,
                DateNaissanceClient = model.DateOfBirth,
                UserRole = "Client",
                SexeClient = model.Gender.ToUpper(),
                MotDePasse = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await dataRepository.Add(user);

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("get-user")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "email").Value;
            var user = await dataRepository.FindByEmail(email);
            if (user.Result == null)
                return StatusCode(StatusCodes.Status404NotFound, new { Status = "Error", Message = "User does not exist!" });

            return Ok(new { Status = "Success", Message = "User found!", User = user.Result });
        }


        // [HttpPost]
        // [Route("forgotpassword")]
        // public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        // {
        //     var user = await dataRepository.FindByEmail(model.Email);
        //     if (user.Result == null)
        //         return StatusCode(StatusCodes.Status404NotFound, new { Status = "Error", Message = "User does not exist!" });

        //     var token = GeneratePasswordResetToken(user.Result);
        //     var link = Url.Action("ResetPassword", "Authenticate", new { token = token, email = user.Result.EmailClient }, Request.Scheme);

        //     return Ok(new { Status = "Success", Message = "Password reset link sent to your email!", Link = link });
        // }
    }
}