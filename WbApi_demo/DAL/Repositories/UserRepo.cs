using DAL.Data;
using DAL.Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        public UserRepo(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        public async Task<UserModel> Login(Login_User_Request request)
        {
            UserModel resp = new UserModel();
            try
            {
                List<AppUser> user = await Context.Users.Where(user => user.Username == request.username).ToListAsync();
                if (user.Count == 0)
                {
                    throw new Exception("Invalid username.");
                }

                using var hmac = new HMACSHA512(user[0].PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                var isPasswordValid = computedHash.SequenceEqual(user[0].PasswordHash);
                if (!isPasswordValid)
                {
                    throw new Exception("Invalid Password");
                }
                resp.Username = user[0].Username;
                resp.Role = user[0].Role;
                resp.IsSuccess = true;
                resp.Message = "Login sucessfull!";
                return resp;
            }
            catch (Exception err)
            {

                return new UserModel
                {
                    IsError = true,
                    Message = err.Message,
                };
            }
        }

        public async Task<UserModel> Register(Register_User_Request request)
        {
            UserModel resp = new UserModel();
            try
            {
                List<AppUser> user = await Context.Users.Where(user => user.Username == request.username).ToListAsync();
                if (user.Count > 0)
                {
                    throw new Exception("Username already exist");
                }
                using var hmac = new HMACSHA512();
                AppUser userToAdd = new AppUser
                {
                    Username = request.username,
                    Role = request.Role,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key
                };
                await Context.Users.AddAsync(userToAdd);
                await Context.SaveChangesAsync();
                resp.IsSuccess = true;
                resp.Message = "User has been registered sucessfully";
                resp.Username = request.username;
                resp.Role = request.Role;
                resp.AuthToken = "";
                return resp;
            }
            catch (Exception err)
            {

                return new UserModel
                {
                    IsError = true,
                    Message = err.Message,
                };
            }
        }
    }
}
