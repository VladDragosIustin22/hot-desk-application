using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
using HotDeskApplicationApi.Models;
using HotDeskApplicationApi.ModelView;
using HotDeskApplicationApi.NewFolder2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReservationController : ControllerBase
    {
        private readonly HotDeskDbContext _dbContext;

        public ReservationController(HotDeskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpGet("{id}")]
        public async Task<EditReservation> GetReservation(Guid id)
        {
            Identity identity = ControllerContext.GetIdentity();

            Profile userProfile = _dbContext.Profile.FirstOrDefault(p => p.ID == identity.ID);

            var reservation = await _dbContext.Reservations.FindAsync(id);

            var office = _dbContext.Offices.ToList().FirstOrDefault(o => o.ID == reservation.OfficeID);

            var floor = _dbContext.Floors.FirstOrDefault(f => f.ID == reservation.FloorID);

            var desk = _dbContext.Desks.FirstOrDefault(d => d.ID == reservation.DeskID);

            

            var reservationView = new EditReservation()
            {
                ReservationID = id,
                ArrivalTime = reservation.ArrivalTime,
                LeavingTime = reservation.LeavingTime,
                OfficeName = office.Name,
                OfficeID = office.ID,
                FloorName = floor.Name,
                FloorID = floor.ID,
                DeskName = desk.Name,
                DeskID = desk.ID,
                
            };

            return reservationView;
        }

        [HttpGet("GetAllProfileReservations")]
      
        public IActionResult GetAllProfileReservations()
        {
            Identity identity = ControllerContext.GetIdentity();

            Profile userProfile = _dbContext.Profile.FirstOrDefault(p => p.ID == identity.ID);

            List<Guid> offices = _dbContext.Offices.Select(o => o.ID).ToList();

            var reservations = _dbContext.Reservations
                .Where(r => r.ProfileID == identity.ID && r.LeavingTime >= DateTime.Now.Date)
                .Select(r => new ReservationView
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
        
        [HttpPut("EditReservation")]
        public async Task<IActionResult> PutReservation(EditReservation reservationEdit)
        {
            Identity identity = ControllerContext.GetIdentity();

            var reservation = new Reservation
            {
                ID = reservationEdit.ReservationID,
                ProfileID = identity.ID,
                ArrivalTime = reservationEdit.ArrivalTime,
                LeavingTime= reservationEdit.LeavingTime,
                OfficeID = reservationEdit.OfficeID,
                FloorID= reservationEdit.FloorID,
                DeskID = reservationEdit.DeskID
            };

            _dbContext.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservationEdit.ReservationID))
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

        private bool ReservationExists(Guid id)
        {
            return (_dbContext.Reservations?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        [HttpPost("MakeReservationForUsers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = AppRoles.Admin)]
        public async Task PostReservationForUsers(AdminReservation adminReservation)
        {
            
            var reservation = new Reservation
            {
                ID = Guid.NewGuid(),
                ProfileID = adminReservation.UserID,
                ArrivalTime = adminReservation.ArrivalTime,
                LeavingTime = adminReservation.LeavingTime,
                OfficeID = adminReservation.OfficeID,
                FloorID = adminReservation.FloorID,
                DeskID = adminReservation.DeskID,
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
