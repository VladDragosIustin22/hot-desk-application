using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Framework.Identity;
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
            Framework.Identity.Identity identity = ControllerContext.GetIdentity();
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

    }
}
