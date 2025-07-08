using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public string GuestName { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool IsResident { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<Room> Rooms { get; } = new List<Room>();
        public bool IsRecurring { get; set; }
        public string SpecialRequests { get; set; }

        public string RoomSummary => string.Join(", ", Rooms.Select(r => $"{r.RoomType} x{r.NumberOfRooms}"));

        public BookingViewModel(Booking booking)
        {
            BookingId = booking.BookingId;
            GuestName = booking.Guest.Name;
            NIC = booking.Guest.NIC;
            Address = booking.Guest.Address;
            MobileNumber = booking.Guest.MobileNumber;
            Email = booking.Guest.Email;
            IsResident = booking.Guest.IsResident;
            CheckInDate = booking.CheckInDate;
            CheckOutDate = booking.CheckOutDate;
            Rooms = booking.Rooms;
            IsRecurring = booking.IsRecurring;
            SpecialRequests = string.Join(", ", booking.SpecialRequests);
        }
    }
}
