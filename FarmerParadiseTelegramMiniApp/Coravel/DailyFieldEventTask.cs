using Coravel.Invocable;
using FarmerParadiseTelegramMiniApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmerParadiseTelegramMiniApp.Coravel
{
    public class DailyFieldEventTask : IInvocable
    {
        private readonly AppIdentityDbContext _context;
        public DailyFieldEventTask(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task Invoke()
        {
            Console.WriteLine("YSPEH!");
            var rand = new Random();
            var allEvents = await _context.FieldEvents.ToListAsync();
            foreach (var user in _context.Users)
            {
                if(user.SownFields < 1)
                {
                    user.FieldEvent = allEvents[rand.Next(allEvents.Count)];
                    _context.Update(user);
                    _context.SaveChanges();
                }
                    
            }
        }
    }
}
