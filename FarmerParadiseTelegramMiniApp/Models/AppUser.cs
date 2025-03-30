using Microsoft.AspNetCore.Identity;

namespace FarmerParadiseTelegramMiniApp.Models
{
    public class AppUser : IdentityUser
    {
        public uint Fields { get; set; }
        public uint SownFields { get; set; }
        public DateTime? SownFieldsDateTime { get; set; }
        public uint Grain { get; set; }
        public uint RareGrain { get; set; }
        public uint Water { get; set; }
        public uint Aucts { get; set; }
        public uint Waxws { get; set; }

        public uint BarnLevel { get; set; }
        public uint WaterTowerLevel { get; set; }

        public uint FieldEventId {  get; set; }
        public FieldEvent FieldEvent { get; set; }

        public bool IsGameAvailable { get; set; }
        public bool IsRouletteAvailable { get; set; }
        public bool IsAdditionalGameAvailable { get; set; }
        public string ReferralLink { get; set; }
        public int InvitedReferralsCount { get; set; }
        public bool HasReferral { get; set; }
        public string PhotoUrl { get; set; }
    }
}
