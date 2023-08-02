using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.ModelView
{
    [Keyless]
    public class ReservationSetUp
    {
        public Guid OfficeID { get; set; }

        public string? OfficeName { get; set; }

        public Guid FloorID { get; set; }

        public string? FloorName { get; set; }

        public Guid? DeskID { get; set; }

        public string? DeskName { get; set; }
    }
}
