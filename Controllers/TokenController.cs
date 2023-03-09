using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektV3.Data;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using ProjektV3.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace ProjektV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IConfiguration configuration;
        private ApplicationDbContext context;
        public TokenController(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        [HttpPost("Authorization")]
        public IActionResult Auth([FromBody]TokenRequestViewModel model)
        {
            if (model == null) return new StatusCodeResult(500);
            return GetToken(model);
        }

        private IActionResult GetToken(TokenRequestViewModel model)
        {
            try
            {
                var user = context.Users.Where(a => a.PESEL == model.pesel);
                if(user == null)
                {
                    return new UnauthorizedResult();
                }
                DateTime now = DateTime.UtcNow;
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.First().Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
                };
                var tokenExpirationMinutes = configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
                var issuerSingnigKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: configuration["Auth:Jwt:Issuer"],
                    audience: configuration["Auth:Jwt:Audience"],
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMinutes)),
                    signingCredentials: new SigningCredentials(issuerSingnigKey, SecurityAlgorithms.HmacSha256)
                );

                var encodingToken = new JwtSecurityTokenHandler().WriteToken(token);

                var response = new TokenResponseViewModel()
                {
                    token = encodingToken,
                    expiration = tokenExpirationMinutes
                };

                return Json(response);
                

            }
            catch(Exception ex)
            {
                return new UnauthorizedResult();
            }
        }


    }
}