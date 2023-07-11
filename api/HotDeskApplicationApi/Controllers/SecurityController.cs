using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]

    public class SecurityController : Controller
    {
        private readonly ProfileContext _dbContext;

        public SecurityController(ProfileContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Security
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfile()
        {
            Framework.Identity.Identity identity = ControllerContext.GetIdentity();


            if (_dbContext.Profile == null)
            {
                return NotFound();
            }
            return await _dbContext.Profile.ToListAsync();
        }
        // GET: api/Security/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(Guid id)
        {
            if (_dbContext.Profile == null)
            {
                return NotFound();
            }
            var profile = await _dbContext.Profile.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Security/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(Guid id, Profile profile)
        {
            if (id != profile.ID)
            {
                return BadRequest();
            }

            _dbContext.Entry(profile).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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

        // POST: api/Security
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            if (_dbContext.Profile == null)
            {
                return Problem("Entity set 'ProfileContext.Profile'  is null.");
            }
            _dbContext.Profile.Add(profile);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.ID }, profile);
        }

        // DELETE: api/Security/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(Guid id)
        {
            if (_dbContext.Profile == null)
            {
                return NotFound();
            }
            var profile = await _dbContext.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _dbContext.Profile.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(Guid id)
        {
            return (_dbContext.Profile?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

