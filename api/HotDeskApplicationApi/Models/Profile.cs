using System;
namespace HotDeskApplicationApi.Models
{
	public class Profile
	{
        public Guid ID { get; set; }

        public string? FirstName { get; set; } = default!;

        public string? LastName { get; set; } = default!;
        public string? Avatar { get; set; } = default!;
        public string? Role { get; set; } = default!;
        public string? NickName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;

    }
}

