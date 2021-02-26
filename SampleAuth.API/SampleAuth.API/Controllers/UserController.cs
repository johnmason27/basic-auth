using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAuth.API.Models;

namespace SampleAuth.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller {

        [Authorize]
        [HttpGet]
        public ActionResult<User> Get() {
            var user = new User();
            user.Name = this.HttpContext.User.Identity.Name.ToString();
            return this.Ok(user);
        }

    }
}
