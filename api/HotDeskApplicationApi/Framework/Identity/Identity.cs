using System;
namespace HotDeskApplicationApi.Framework.Identity
{
	public class Identity
	{
        public Guid ID { get; set; }

        public Guid? OriginatorID { get; set; }

        public static class IdentityConstants
        {
            public const string IdentityKey = "HotDeskApplicationApi_IdentityClaim_Key";
        }
    }
}

