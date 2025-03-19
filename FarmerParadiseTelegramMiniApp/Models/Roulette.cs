namespace FarmerParadiseTelegramMiniApp.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public string[] Items { get; set; } // Элементы рулетки
        public string Result { get; set; }  // Результат вращения
    }
}
