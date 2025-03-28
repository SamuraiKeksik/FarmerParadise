using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace FarmerParadiseTelegramMiniApp.Controllers;

[Authorize]
public class HomeController : Controller
{
    uint grainPerField = 100;
    private readonly AppIdentityDbContext _context;
    private readonly UserManager<AppUser> _userManager;  
    private readonly ILogger<HomeController> _logger;
    private const uint MaxGrainMultiplier = 100;

    public HomeController(AppIdentityDbContext context, UserManager<AppUser> userManager, ILogger<HomeController> logger)
    {
        _context = context;
        _userManager = userManager; 
        _logger = logger;
    }

    // Главная страница – обзорная карта 10×10
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Auth");
        }
        ViewData["MaxGrain"] = user.BarnLevel * MaxGrainMultiplier;
        ViewData["GrainPerField"] = grainPerField;
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> SowFields([FromForm] uint fieldsCount)
    {        
        var user = await _userManager.GetUserAsync(User);
        var maxFields = uint.Min(user.Grain / grainPerField, user.Fields - user.SownFields);
        if (fieldsCount > maxFields)
            fieldsCount = maxFields;

        user.SownFields += fieldsCount;
        user.Grain -= fieldsCount * grainPerField;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index"); 
    }

    public IActionResult SubMap(int? mainNumber)
    {
        if (mainNumber == null)
        {
            return BadRequest("Некорректный номер ячейки."); // 400 Bad Request
        }

        string letterSuffix = GetLetterSuffix(mainNumber.Value);
        ViewData["MainNumber"] = mainNumber;
        ViewData["LetterSuffix"] = letterSuffix;

        return View();
    }

    private string GetLetterSuffix(int number)
    {
        StringBuilder suffix = new StringBuilder();
        number--; // Смещаем, чтобы A начиналось с 1, а не 0

        while (number >= 0)
        {
            suffix.Insert(0, (char)('A' + (number % 26)));
            number = number / 26 - 1;
        }

        return suffix.ToString();
    }

    public ActionResult Project()
    {
        return View();
    }

    public ActionResult Contact()
    {
        return View();
    }

    public ActionResult Saper()
    {
        return View();
    }

    public ActionResult Auctions()
    {
        return View();
    }

    public ActionResult Market()
    {
        return View();
    }
    

    public ActionResult Roulette()
    {
        return View();
    }
    public ActionResult Roulette2()
    {
        return View();
    }

    public async Task<IActionResult> Friends()
    {
        var user = await _userManager.GetUserAsync(User); 
        if (user == null)
        {
            return RedirectToAction("Auth");
        }
        return View(user);
    }

    public ActionResult Profile()
    {
        return View();
    }

    public ActionResult Auth()
    {
        return View();
    }

    public IActionResult Map()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

