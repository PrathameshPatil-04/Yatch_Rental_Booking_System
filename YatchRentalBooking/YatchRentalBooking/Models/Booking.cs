using YachtRentalBooking.Models;

namespace YatchRentalBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public Boat Boat { get; set; }
        public int Hours { get; set; }
        public decimal TotalAmount { get; set; }
    }
}