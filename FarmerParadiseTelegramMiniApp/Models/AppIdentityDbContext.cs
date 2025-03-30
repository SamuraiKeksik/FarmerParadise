using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Telegram.Bot.Types;

namespace FarmerParadiseTelegramMiniApp.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FieldEvent>().HasData(
                    new FieldEvent
                    {
                        Id = 1,
                        Name = "None",
                        Description = "None",
                        IsGoodEvent = true,
                        SowGrainCostModifier = 1,
                        SowWaterCostModifier = 1,
                        YieldModifier = 1,
                    },
                    new FieldEvent
                    {
                        Id = 2,
                        Name = "Засуха",
                        IsGoodEvent = false,
                        Description = "Засуха - описание",
                        SowGrainCostModifier = 1,
                        SowWaterCostModifier = 2,
                        YieldModifier = 0.8,
                    }
            );
        }

        public DbSet<FieldEvent> FieldEvents { get; set; }
    }
}
