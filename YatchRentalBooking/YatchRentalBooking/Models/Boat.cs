namespace YachtRentalBooking.Models
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal PricePerHour { get; set; }
        public bool IsAvailable { get; set; }

        public string ImagePath { get; set; }
    }
}