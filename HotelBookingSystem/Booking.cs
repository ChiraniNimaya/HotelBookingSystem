using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal class Booking
    {
        public Guest Guest { get; set; }
        public Guid BookingId { get; set; } = Guid.NewGuid();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string SpecialRequests { get; set; }
        public Room Room { get; set; }
        public float TotalPrice { get; set; }
    }
}
