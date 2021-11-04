using System.Collections.Generic;

namespace DaytaCare.Models.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Token { get; internal set; }
        public IList<string> Roles { get; set; }
    }
}
