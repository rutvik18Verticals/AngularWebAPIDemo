using DAL.Repositories;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserRepo repo,ITokenService token)
        {
            Repo = repo;
            Token = token;
        }

        public IUserRepo Repo { get; }
        public ITokenService Token { get; }

        public async Task<UserModel> Login(Login_User_Request request)
        {
           UserModel resp = await Repo.Login(request);
            if (resp.IsSuccess)
            {
                resp.AuthToken = Token.GenerateToken(resp.Username, resp.Role);
            }
            return resp;
        }

        public async Task<UserModel> Register(Register_User_Request request,ClaimsIdentity identity)
        {
            UserModel resp = await Repo.Register(request);
            if (resp.IsSuccess)
            {
                resp.AuthToken = Token.GenerateToken(resp.Username,resp.Role);
            }
            return resp;
        }

    }
}
