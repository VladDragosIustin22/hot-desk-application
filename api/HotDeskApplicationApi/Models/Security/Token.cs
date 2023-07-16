using System;
namespace HotDeskApplicationApi.Models.Security
{
	public class Token
	{
        public string Value { get; set; }

        public DateTime Expiry { get; set; }
    }
}

