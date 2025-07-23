using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        public int BookingId { get; set; }
        
        private static int s_lastBookingId = 0;
        public Guest Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string SpecialRequests { get; set; }
        public List<Room> Rooms { get; } = new List<Room>();
        public float TotalPrice { get; set; }

        public Booking()
        {
        }
        public Booking(Guest guest, DateTime checkIn, DateTime checkOut, bool isRecurring, string specialRequests, List<Room> rooms)
        {
            Guest = guest;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            IsRecurring = isRecurring;
            SpecialRequests = specialRequests;
            Rooms = rooms;
        }
    }
}


