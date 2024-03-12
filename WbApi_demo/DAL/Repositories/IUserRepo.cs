using DAL.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepo
    {
        Task<UserModel> Login(Login_User_Request request);
        Task<UserModel> Register(Register_User_Request request);
    }
}
