using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.NewFolder2
{
    [Keyless]
    public class RegistrationView
    {
        public Guid ReservationID { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime LeavingTime { get; set; }

        public string? OfficaName { get; set; }

        public string? FloorName { get; set; }

        public string? DeskName { get; set; }

        public byte[]? Avatar { get; set; }

        public string? ProfileRole { get; set; }

        public string? ProfileName { get; set; }
    }
}
