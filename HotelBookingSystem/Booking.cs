using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal class Booking
    {
        public Guid BookingId { get; set; } = Guid.NewGuid();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool isRecurring { get; set; }
        public List<string> SpecialRequests { get; set; } = new();
        public Room room { get; set; }
        public float totalPrice { get; set; }
    }
}
