using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FarmerParadiseTelegramMiniApp.Controllers
{
    public class AuthController : Controller
    {
        private AppIdentityDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly string _botToken;

        public AuthController(AppIdentityDbContext context, UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _botToken = configuration.GetValue<string>("BotToken");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ObjectResult> Login([FromBody] TelegramInitData initData)
        {
            await _signInManager.SignOutAsync();
            var user = _context.Users.First();
            await _signInManager.SignInAsync(user, true);
            return Ok(new { Message = "Authenticated" });

            //if (string.IsNullOrEmpty(initData.InitData))
            //    return BadRequest("InitData is missing.");

            //// Разбираем initData
            //var parsedData = ParseInitData(initData.InitData);

            //// Проверяем подпись
            //if (!ValidateInitData(parsedData))
            //    return Unauthorized("Invalid signature.");

            //// Получаем данные пользователя
            //var parsedUser = JObject.Parse(parsedData["user"]).ToObject<TelegramUser>();
            //var user = await _userManager.FindByIdAsync(parsedUser.Id.ToString());
            //if (user != null)
            //{
            //    await _signInManager.SignOutAsync();

            //    user.PhotoUrl = parsedUser.Photo_Url;
            //    await _userManager.UpdateAsync(user);
            //    await _signInManager.SignInAsync(user, true);
            //    return Ok(new { Message = "Authenticated" });
            //}

            //else
            //{
            //    AppUser newUser = new AppUser()
            //    {
            //        Id = parsedUser.Id.ToString(),
            //        UserName = parsedUser.Username,
            //        PhotoUrl = parsedUser.Photo_Url,
            //        ReferralLink = Guid.NewGuid().ToString(),
            //        InvitedReferralsCount = 0,
            //    };
            //    IdentityResult result = await _userManager.CreateAsync(newUser);
            //    if (result.Succeeded)
            //    {
            //        await _signInManager.SignOutAsync();
            //        await _signInManager.SignInAsync(newUser, true);
            //        return Ok(new { Message = "Authenticated" });
            //    }
            //    else
            //    {
            //        return BadRequest("Can't create account");
            //    }
            //}
        }

        private static Dictionary<string, string> ParseInitData(string initData)
        {
            return initData.Split('&')
                .Select(part => part.Split('='))
                .ToDictionary(split => split[0], split => Uri.UnescapeDataString(split[1]));
        }

        private bool ValidateInitData(Dictionary<string, string> parsedData)
        {
            if (!parsedData.ContainsKey("hash") || !parsedData.ContainsKey("user"))
                return false;

            var hash = parsedData["hash"];
            var dataCheckString = string.Join("\n", parsedData
                .Where(kv => kv.Key != "hash")
                .OrderBy(kv => kv.Key)
                .Select(kv => $"{kv.Key}={kv.Value}"));

            Console.Write("DataCheckString:");
            Console.WriteLine(dataCheckString);

            byte[] secret_key = HMAC_SHA256(Encoding.UTF8.GetBytes(_botToken), Encoding.UTF8.GetBytes("WebAppData"));
            string calculatedHash = BitConverter.ToString(HMAC_SHA256(Encoding.UTF8.GetBytes(dataCheckString), secret_key)).Replace("-", "").ToLower();


            return calculatedHash == hash.ToLower();
        }

        private static byte[] HMAC_SHA256(byte[] data, byte[] key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }
    }

    public class TelegramUser
    {
        public long Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Username { get; set; }
        public string Photo_Url { get; set; }
    }
}

