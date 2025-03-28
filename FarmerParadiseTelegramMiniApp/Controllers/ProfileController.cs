using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmerParadiseTelegramMiniApp.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppIdentityDbContext _context;

        public ProfileController(UserManager<AppUser> userManager, AppIdentityDbContext context) 
        {
            _userManager = userManager;
            _context = context;
        }
        

        //[HttpGet]
        //public async Task<IActionResult> ProfileInfo()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }


        //}
    }
}
