using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OfficeController : Controller
    {
        private HotDeskDbContext dbContext;

        public OfficeController(HotDeskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            if (dbContext.Offices == null)
            {
                return NotFound();
            }
            return await dbContext.Offices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(Guid id)
        {

            var office = await dbContext.Offices.FindAsync(id);

            if (office == null)
            {
                return this.NotFound();
            }
            return office;
        }

        [HttpPost]
        public async Task<ActionResult<Office>> PostOfficies(Office office)
        {
            dbContext.Offices.Add(office);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetOffice", new { id = office.ID }, office);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffices(Guid id)
        {

            var office = await dbContext.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            dbContext.Offices.Remove(office);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffice(Guid id, Office office)
        {

            dbContext.Entry(office).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        private bool OfficeExists(Guid id)
        {
            return (dbContext.Offices?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}
