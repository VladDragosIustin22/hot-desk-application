using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.NewFolder2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ReservationController : ControllerBase
    {
        private readonly HotDeskDbContext _dbContext;

        public ReservationController(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllProfileReservations/{profileID}")]
        public IActionResult GetAllProfileReservations(Guid profileID)
        {

            var reservations = _dbContext.Reservations
            .Where(r => r.ProfileID == profileID)
            .Select(r => new RegistrationView
            {
                ProfileID = profileID,
                ArrivalTime = r.ArrivalTime,
                LeavingTime = r.LeavingTime,
                OfficaName = _dbContext.Offices.FirstOrDefault(o => o.ID == r.OfficeID).Name,
                FloorName = _dbContext.Floors.FirstOrDefault(f => f.ID == r.FloorID).Name,
                DeskName = _dbContext.Desks.FirstOrDefault(d => d.ID == r.DeskID).Name,
                Avatar = _dbContext.Profile.FirstOrDefault(p => p.ID == profileID).Avatar,
                ProfileRole = _dbContext.Profile.FirstOrDefault(p => p.ID == profileID).Role,
                ProfileName = _dbContext.Profile.FirstOrDefault(p => p.ID == profileID).FirstName
            })
            .ToList();

            return Ok(reservations);
        }
        [HttpGet("{id}")]
        public async Task<Reservation> GetReservation(Guid id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            return reservation;
        }
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {

            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.ID }, reservation);
        }

        [HttpGet("AvailableDesks")]
        public async Task<Desk[]> CheckDeskAvailability(DateTime arrivalTime, DateTime leavingTime, Guid officeID, Guid floorID)
        {

            var reservedDeskIDs = await _dbContext.Reservations
                .Where(r => r.OfficeID == officeID && r.FloorID == floorID && !(r.ArrivalTime >= leavingTime || r.LeavingTime <= arrivalTime))
                .Select(r => r.DeskID)
                .ToListAsync();


            var availableDesks = await _dbContext.Desks
                .Where(d => d.FloorID == floorID && !reservedDeskIDs.Contains(d.ID))
                .ToArrayAsync();

            return availableDesks;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {

            var reservation = await _dbContext.Reservations.FindAsync(id);

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
