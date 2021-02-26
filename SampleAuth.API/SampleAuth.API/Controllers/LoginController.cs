using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SampleAuth.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller {

        [AllowAnonymous]
        [HttpGet]
        public ActionResult IsUserLoggedIn() {
            if (!this.HttpContext.User.Identity.IsAuthenticated) {
                return this.Unauthorized();
            }
            
            return this.Accepted();
        }
        
        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public async Task Login() {
            if (!this.HttpContext.User.Identity.IsAuthenticated) {
                this.HttpContext.Items.Add("allowRedirect", true);
                await this.HttpContext.ChallengeAsync();
                return;
            }

            this.HttpContext.Response.Redirect("https://localhost/basicauth");
        }

    }

}
