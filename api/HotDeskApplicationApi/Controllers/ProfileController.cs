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

        [HttpPut("EditProfile")]
        public async Task<IActionResult> PutProfile(UserProfile userProfile)
        {
            Identity identity = ControllerContext.GetIdentity();

            Guid profileID = identity.ID;

            Profile user = hotDeskDbContext.Profile.FirstOrDefault(p => p.ID == profileID);

            user.Avatar = userProfile.Avatar;
            user.Role = userProfile.Role;
            user.NickName = userProfile.NickName;

            try
            {
                await hotDeskDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(profileID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        [HttpGet("searchProfiles")]
        public ActionResult<UserProfile[]> SearchUserProfiles(string userName)
        {
            var AllUserProfiles = hotDeskDbContext.Profile.ToList();

            Identity identity = ControllerContext.GetIdentity();

            var profiles = AllUserProfiles
                   .Where(profile =>
                       profile.NickName.Contains(userName, StringComparison.OrdinalIgnoreCase) &&
                       profile.ID != identity.ID
                   )
                   .ToList();

            return Ok(profiles);

        }
            private bool ProfileExists(Guid id)
        {
            return (hotDeskDbContext.Profile?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}