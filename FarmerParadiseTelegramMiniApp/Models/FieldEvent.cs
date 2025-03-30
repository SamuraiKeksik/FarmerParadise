namespace FarmerParadiseTelegramMiniApp.Models
{
    public class FieldEvent
    {
        public uint Id { get; set; }
        public string Name { get; set; } //Название события
        public string Description { get; set; } //Описание события
        public bool IsGoodEvent { get; set; } //Хорошее или плохое событие
        public double YieldModifier { get; set; } //Модификатор урожайности, например 0,9 чтобы уменьшить урожайность с полей
        public double SowGrainCostModifier { get; set; } //Модификатор стоимости засеивания полей для зерна
        public double SowWaterCostModifier { get; set; } //Модификатор стоимости засеивания полей для воды
        
    }
}
