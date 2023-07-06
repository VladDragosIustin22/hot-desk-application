using System;
namespace HotDeskApplicationApi.Models
{
	public class User
	{
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
    }
}

