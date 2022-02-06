using System;
namespace Odev4.WebApi.Token
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
