using BLL.Services;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService service)
        {
            Service = service;
        }

        public IUserService Service { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserModel> Register(Register_User_Request request)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            UserModel resp = await Service.Register(request, identity);
            return resp;
        }
    }
}
