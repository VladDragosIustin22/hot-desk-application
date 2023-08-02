using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.NewFolder2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    public class ReservationController : ControllerBase
    {
        private readonly HotDeskDbContext _dbContext;

        public ReservationController(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpGet("{id}")]
        public async Task<Reservation> GetReservation(Guid id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);
            return reservation;
        }

        [HttpGet("GetAllProfileReservations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAllProfileReservations()
        {
            Framework.Identity.Identity identity = ControllerContext.GetIdentity();
            
            Guid userID = identity.ID;

            Profile userProfile = _dbContext.Profile.FirstOrDefault(p => p.ID == userID);

            var reservations = _dbContext.Reservations
                .Where(r => r.ProfileEmail == userProfile.EmailAddress)
                .Select(r => new RegistrationView
                {
                    ReservationID = r.ID,
                    ArrivalTime = r.ArrivalTime,
                    LeavingTime = r.LeavingTime,
                    OfficaName = _dbContext.Offices.FirstOrDefault(o => o.ID == r.OfficeID).Name,
                    FloorName = _dbContext.Floors.FirstOrDefault(f => f.ID == r.FloorID).Name,
                    DeskName = _dbContext.Desks.FirstOrDefault(d => d.ID == r.DeskID).Name,
                    Avatar = _dbContext.Profile.FirstOrDefault(p => p.EmailAddress == userProfile.EmailAddress).Avatar,
                    ProfileRole = _dbContext.Profile.FirstOrDefault(p => p.EmailAddress == userProfile.EmailAddress).Role,
                    ProfileName = _dbContext.Profile.FirstOrDefault(p => p.EmailAddress == userProfile.EmailAddress).NickName
                })
                .ToList();

    return Ok(reservations);
    
    }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {

            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.ID }, reservation);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
