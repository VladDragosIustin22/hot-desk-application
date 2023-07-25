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
    public class DeskController : ControllerBase
    {
        private HotDeskDbContext hotDeskDbContext;

        public DeskController(HotDeskDbContext dbContext)
        {
            hotDeskDbContext = dbContext;
        }

        [HttpGet]
        public async Task<Desk[]> GetReservation()
        {
            return await hotDeskDbContext.Desks.ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Desk>> PostDesk(Desk desk)
        {
            hotDeskDbContext.Desks.Add(desk);
            await hotDeskDbContext.SaveChangesAsync();

            return CreatedAtAction("GetDesk", new { id = desk.ID }, desk);
        }


        [HttpGet("{id}")]
        public async Task<Desk> GetDesk(Guid id)
        {
            var desk = await hotDeskDbContext.Desks.FindAsync(id);
            return desk;
        }

        [HttpGet("byFloor/{floorID}")]
        public async Task<Desk[]> GetDeskByFloor(Guid floorID)
        {
            var desks = await hotDeskDbContext.Desks.Where(d => d.FloorID == floorID).ToArrayAsync();
            return desks;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(Guid id)
        {

            var desk = await hotDeskDbContext.Desks.FindAsync(id);

            if (desk == null)
            {
                return NotFound();
            }

            hotDeskDbContext.Desks.Remove(desk);
            await hotDeskDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesk(Guid id, Desk desk)
        {

            hotDeskDbContext.Entry(desk).State = EntityState.Modified;

            try
            {
                await hotDeskDbContext.SaveChangesAsync();
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
            return (hotDeskDbContext.Desks?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}
