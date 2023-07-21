using System;
namespace HotDeskApplicationApi.Models
{
	public class Profile
	{
        public Guid ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
    }
}

