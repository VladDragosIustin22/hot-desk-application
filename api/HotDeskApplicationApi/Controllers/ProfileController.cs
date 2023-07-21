using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly HotDeskDbContext dbContext;

        public ProfileController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            HotDeskDbContext dbContext
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.dbContext = dbContext;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<Token> Register(RegisterModel registerModel)
        {
            IdentityUser identityUser = new IdentityUser() { Email = registerModel.Email, UserName = registerModel.Email };

            IdentityResult result = await userManager.CreateAsync(identityUser, registerModel.Password);

            IdentityUser user = await userManager.FindByEmailAsync(registerModel.Email);

            Profile profile = new Profile()
            {
                ID = Guid.Parse(user.Id),
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                EmailAddress = registerModel.Email,
            };

            dbContext.Profile.Add(profile);

            dbContext.SaveChanges();

            return new Token();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Token> Login(LoginModel loginModel)
        {
            IdentityUser identityUser = await userManager.FindByEmailAsync(loginModel.Email);

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.CheckPasswordSignInAsync(identityUser, loginModel.Password, true);

            return GenerateToken(identityUser);
        }

        private Token GenerateToken(IdentityUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<string>("Authentication:Secret")));

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("Authentication:Issuer"),
            audience: configuration.GetValue<string>("Authentication:Issuer"),
            claims: claims,
            expires: DateTime.Now.AddDays(this.configuration.GetValue<int>("Authentication:ExpiryTimeInDays")),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        );

            return new Token()
            {
                Value = new JwtSecurityTokenHandler().WriteToken(token),
                Expiry = token.ValidTo,
            };
        }

    }
}

