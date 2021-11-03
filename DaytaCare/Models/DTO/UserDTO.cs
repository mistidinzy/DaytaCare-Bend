using System;
using System.Threading.Tasks;

namespace DaytaCare.Models.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Token { get; internal set; }
    }
}
