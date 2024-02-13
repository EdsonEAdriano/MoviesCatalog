using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.API.Models;
using MoviesCatalog.Domain.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _auth;
        private readonly IConfiguration _config;

        public TokenController(IAuthenticate auth, IConfiguration config)
        {
            _auth = auth ??
                throw new ArgumentNullException(nameof(auth));

            _config = config;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Authenticate(userInfo.Email, userInfo.Password);

                if (result)
                {
                    return GenerateToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return BadRequest(ModelState);
                }
                    
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }
        }

        [HttpPost("RegisterUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Register([FromBody] LoginModel userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.RegisterUser(userInfo.Email, userInfo.Password);

                if (result)
                {
                    return Ok($"User {userInfo.Email} was created succefullyy.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return BadRequest(ModelState);
                }

            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("myValue", "value"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding
                                                        .UTF8
                                                        .GetBytes(_config["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
