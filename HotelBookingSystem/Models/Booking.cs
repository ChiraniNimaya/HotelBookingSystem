using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        public int BookingId { get; private set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string? SpecialRequests { get; set; }
        public Guest Guest { get; set; }

        public int GuestId { get; set; }
        public List<int> RoomIds { get; set; }

        public float TotalPrice { get; set; }

        public Booking(int bookingId, Guest guest, DateTime checkIn, DateTime checkOut, bool isRecurring, string specialRequests, List<int> roomIds)
        {
            BookingId = bookingId;
            Guest = guest;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            IsRecurring = isRecurring;
            SpecialRequests = specialRequests;
            RoomIds = roomIds;
        }
    }
}


