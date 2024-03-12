using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        Task<UserModel> Login(Login_User_Request request);
        Task<UserModel> Register(Register_User_Request request,ClaimsIdentity identity);
    }
}
