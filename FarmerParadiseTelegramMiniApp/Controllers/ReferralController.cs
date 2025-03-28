using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmerParadiseTelegramMiniApp.Controllers
{
    public class ReferralRequest
    {
        public string ReferralLink { get; set; }
    }

    [ApiController]
    [Authorize]
    [Route("Api/[Controller]")]
    public class ReferralController : ControllerBase
    {
        private readonly AppIdentityDbContext _context;
        private UserManager<AppUser> _userManager;
        public ReferralController(AppIdentityDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [HttpPost("Check")]
        public async Task<IActionResult> Check([FromBody] ReferralRequest referralRequest)
        {
            var referralUser = _context.Users.FirstOrDefault(x => x.ReferralLink == referralRequest.ReferralLink);
            var invitedUser = await _userManager.GetUserAsync(User);
            if (referralUser != null)
            {
                if(invitedUser.HasReferral)
                    return BadRequest("Already has referral");

                referralUser.InvitedReferralsCount++;
                referralUser.Grain += 100;
                referralUser.Water += 5;
                invitedUser.HasReferral = true;
                invitedUser.Grain += 100;
                invitedUser.Water += 5;
                _context.Users.Update(referralUser);
                _context.Users.Update(invitedUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Invalid referralLink");
            }
        }
    }
}
