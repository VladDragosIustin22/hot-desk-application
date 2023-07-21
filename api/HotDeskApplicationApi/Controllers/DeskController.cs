using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotDeskApplicationApi.Controllers
{
    [Authorize]
    [Route("desk/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private HotDeskDbContext dbContext;

        public DeskController(HotDeskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desk>>> GetReservation()
        {
            if (dbContext.Desks == null)
            {
                return NotFound();
            }
            return await dbContext.Desks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            
            dbContext.Desks.Add(desk);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetDesk", new { id = desk.ID }, desk);
        }
       

        [HttpGet("{id}")]
        public async Task<ActionResult<Desk>> GetDesk(Guid id)
        {

            var desk = await dbContext.Desks.FindAsync(id);

            if (desk == null)
            {
                return this.NotFound();
            }
            return desk;
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(Guid id)
        {

            var desk = await dbContext.Desks.FindAsync(id);

            if (desk == null)
            {
                return NotFound();
            }

            dbContext.Desks.Remove(desk);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesk(Guid id, Desk desk)
        {

            dbContext.Entry(desk).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(id))
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

        private bool DeskExists(Guid id)
        {
            return (dbContext.Desks?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
