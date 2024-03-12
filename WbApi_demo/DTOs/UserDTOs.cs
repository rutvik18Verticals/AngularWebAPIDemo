using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Login_User_Request
    {
        public string username { get; set; }
        public string Password { get; set; }
    }

    public class Register_User_Request: Login_User_Request
    {
        public string Role { get; set; }
    }

    public class UserModel:CommonMessages_DTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string AuthToken { get; set; }
    }
}
