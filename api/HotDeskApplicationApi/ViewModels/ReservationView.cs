namespace HotDeskApplicationApi.ViewModels
{
    public class ReservationView
    {
        public DateTime? ArrivalTime { get; set; }
        public DateTime? LeavingTime { get; set; }
        public string? OfficeName { get;set; }
        public string? Floor { get; set; }
        public string? Desk { get; set; }
    }
}
