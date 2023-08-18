using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.ModelView;
using HotDeskApplicationApi.NewFolder2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet("availableDesks")]
        public IActionResult GetAvailableDesks(DateTime arrivalTime,DateTime leavingTime,Guid? id = null)
        {

            List<Guid> busyDeskIds = hotDeskDbContext.Reservations
                    .Where(r => ((r.ArrivalTime < leavingTime && r.LeavingTime > arrivalTime)
                        || (r.ArrivalTime >= arrivalTime && r.ArrivalTime < leavingTime)) && r.ID != id)
                    .Select(r => r.DeskID)
                    .ToList();

            List<ReservationSetUp> availableDesks = hotDeskDbContext.Desks
                    .Where(d => !busyDeskIds.Contains(d.ID))
                    .Select(d => new ReservationSetUp
                    {
                        DeskID = d.ID,
                        DeskName = d.Name,
                        FloorID = d.FloorID,
                        FloorName = hotDeskDbContext.Floors.FirstOrDefault(f => f.ID == d.FloorID).Name,
                        OfficeID = d.OfficeID,
                        OfficeName = hotDeskDbContext.Offices.FirstOrDefault(o => o.ID == d.OfficeID).Name,
                    })
                    .ToList();
           
            return Ok(availableDesks);
        }
        private bool DeskExists(Guid id)
        {
            return (hotDeskDbContext.Desks?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

}
