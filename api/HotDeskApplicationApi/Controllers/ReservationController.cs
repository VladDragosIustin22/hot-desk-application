using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.ModelView;
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
                .Where(r => r.ProfileID == identity.ID)
                .Select(r => new RegistrationView
                {
                    ReservationID = r.ID,
                    ArrivalTime = r.ArrivalTime,
                    LeavingTime = r.LeavingTime,
                    OfficaName = _dbContext.Offices.FirstOrDefault(o => o.ID == r.OfficeID).Name,
                    FloorName = _dbContext.Floors.FirstOrDefault(f => f.ID == r.FloorID).Name,
                    DeskName = _dbContext.Desks.FirstOrDefault(d => d.ID == r.DeskID).Name,
                    Avatar = userProfile.Avatar,
                    ProfileRole = userProfile.Role,
                    ProfileName = userProfile.NickName
                })
                .ToList();

    return Ok(reservations);
    
    }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task PostReservation(ReservationInput reservationInput)
        {
            Identity identity = ControllerContext.GetIdentity();

            var reservation = new Reservation
            {
                ID = Guid.NewGuid(),
                ProfileID = identity.ID,
                ArrivalTime = reservationInput.ArrivalTime,
                LeavingTime = reservationInput.LeavingTime,
                OfficeID = reservationInput.OfficeID,
                FloorID = reservationInput.FloorID,
                DeskID = reservationInput.DeskID,
            };

            _dbContext.Reservations.Add(reservation);

            await _dbContext.SaveChangesAsync();
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
