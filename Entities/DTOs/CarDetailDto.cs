using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}