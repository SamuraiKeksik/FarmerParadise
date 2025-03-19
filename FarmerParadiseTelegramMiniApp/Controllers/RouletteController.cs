using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmerParadiseTelegramMiniApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Api/[Controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly AppIdentityDbContext _context;
        private UserManager<AppUser> _userManager;
        private const uint WaterJeckpot = 10;
        private const uint GrainJeckpot = 10;
        private const uint RareGrainJeckpot = 10;
        private const uint WaxwsJeckpot = 10;

        public RouletteController(AppIdentityDbContext context, UserManager<AppUser> userManager)
        {
        _context = context;
        _userManager = userManager; 
        }

        private static readonly List<string> ItemsList = new List<string>
        {
        "Barn", "WaterTower", "Water", "Grain", "RareGrain", "Waxws"
        };

        [HttpGet("Spin")]
        public async Task<IActionResult> Spin()
        {
            var random = new Random();
            var result = ItemsList[random.Next(ItemsList.Count)];
            var user = await _userManager.GetUserAsync(User);
            user.IsRouletteAvailable = false;
            switch (result)
            {
                case "Barn":
                    user.BarnLevel++;
                    _context.Users.Update(user);
                    break;
                case "WaterTower":
                    user.WaterTowerLevel++;
                    _context.Users.Update(user);
                    break;
                case "Water":
                   user.Water += WaterJeckpot;
                    _context.Users.Update(user);
                    break;
                case "Grain":
                    user.Grain += GrainJeckpot;
                    _context.Users.Update(user);
                    break;
                case "RareGrain":
                    user.RareGrain += RareGrainJeckpot;
                    _context.Users.Update(user);
                    break;
                case "Waxws":
                    user.Waxws += WaxwsJeckpot;
                    _context.Users.Update(user);
                    break;
            }
            await _context.SaveChangesAsync();

            return Ok(new {Result = result});
        }

        [HttpGet("Items")]
        public async Task<IActionResult> Items()
        {
            return Ok(new { Items = ItemsList });
        }

        [HttpGet("CanPlayRoulette")]
        public async Task<IActionResult> CanPlayRoulette()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user.IsRouletteAvailable)
                return Ok(new { CanPlay = true });
            else            
                return Ok(new { CanPlay = false});
            
        }


    }
}
