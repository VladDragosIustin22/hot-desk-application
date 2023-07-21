using HotDeskApplicationApi.Data;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Controllers
{
    [Authorize]
    [Route("reservation/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly HotDeskDbContext dbContext;

        public ReservationController(HotDeskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetReservation()
        {
            var items = dbContext
                .ReservationViews
                .Select(x => new
                {
                    ArrivalTime = x.ArrivalTime,
                    LeavingTime = x.LeavingTime,
                    OfficeName = x.OfficeName,
                    Floor = x.Floor,
                    Desk = x.Desk,
                })
                .OrderByDescending(x => x.ArrivalTime);

            return Ok(items);
        }
    }
}
