using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Migrations;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.ModelView;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly HotDeskDbContext hotDeskDbContext;

        public ProfileController(HotDeskDbContext dbContext)
        {
            hotDeskDbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = AppRoles.Admin)]
        public async Task<Profile[]> ListProfiles()
        {
            return await hotDeskDbContext.Profile.ToArrayAsync();
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            Identity identity = ControllerContext.GetIdentity();

            Profile userProfile = hotDeskDbContext.Profile.FirstOrDefault(p => p.ID == identity.ID);

            var profile = new UserProfile
            {
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Avatar = userProfile.Avatar,
                Role = userProfile.Role,
                NickName = userProfile.NickName,
                EmailAddress = userProfile.EmailAddress,

            };
            //var profile = await hotDeskDbContext.Profile.FindAsync(identity.ID);

            return Ok(profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(Guid id, Profile profile)
        {
            hotDeskDbContext.Entry(profile).State = EntityState.Modified;

            try
            {
                await hotDeskDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            if (hotDeskDbContext.Profile == null)
            {
                return Problem("Entity set 'ProfileContext.Profile'  is null.");
            }

            hotDeskDbContext.Profile.Add(profile);

            await hotDeskDbContext.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.ID }, profile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(Guid id)
        {
            var profile = await hotDeskDbContext.Profile.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            hotDeskDbContext.Profile.Remove(profile);

            await hotDeskDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(Guid id)
        {
            return (hotDeskDbContext.Profile?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}