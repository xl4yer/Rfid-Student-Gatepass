using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rfid.Models;
using Rfid.Services;

namespace Rfid.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        UserServices xservices;

        public UserController(UserServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<users>> Login(string username, string password)
        {
            var ret = await xservices.Login(username, password);
            return ret;
        }

        [HttpPut]
        public async Task<int> Settings([FromBody] users xuser)
        {
            var ret = await xservices.Settings(xuser);
            return ret;
        }
    }
}
