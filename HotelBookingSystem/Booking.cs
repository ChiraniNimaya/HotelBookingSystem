using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        private static int s_lastBookingId = 0;
        public Guest Guest { get; set; }
        public int BookingId { get; private set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string SpecialRequests { get; set; }
        public Room Room { get; set; }
        public float TotalPrice { get; set; }

        public Booking(Guest guest, DateTime checkIn, DateTime checkOut, bool isRecurring, string specialRequests, Room room)
        {
            BookingId = ++s_lastBookingId; // Auto-incrementing ID
            Guest = guest;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            IsRecurring = isRecurring;
            SpecialRequests = specialRequests;
            Room = room;
        }
    }
}
