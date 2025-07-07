using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal class BookingManager
    {
        public static List<Booking> Bookings { get; } = new List<Booking>();

        public static readonly Dictionary<RoomType, int> TotalRoomsPerType = new()
        {
            { RoomType.Single, 5 },
            { RoomType.Double, 7 },
            { RoomType.Triple, 4 }
        };


        public static void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }

        public static List<Booking> GetAllBookings()
        {
            return Bookings;
        }

        public static IEnumerable<Booking> GetBookingsForCurrentWeek()
        {
            DateTime today = DateTime.Today;
            // Get start (Monday) and end (Sunday) of the current week
            int daysSinceMonday = ((int)today.DayOfWeek + 6) % 7;
            DateTime weekStart = today.AddDays(-daysSinceMonday); // Monday
            DateTime weekEnd = weekStart.AddDays(6); // Sunday

            return Bookings.Where(b =>
                b.CheckInDate.Date >= weekStart && b.CheckInDate.Date <= weekEnd ||
                b.CheckOutDate.Date >= weekStart && b.CheckOutDate.Date <= weekEnd
            );
        }
        public static bool IsRoomTypeAvailable(RoomType type, DateTime checkIn, DateTime checkOut)
        {
            int overlappingBookings = Bookings.Count(b =>
                b.Room.RoomType == type &&
                !(b.CheckOutDate <= checkIn || b.CheckInDate >= checkOut) 
            );

            return overlappingBookings < TotalRoomsPerType[type];
        }
        public static bool IsAnyRoomAvailable(DateTime checkIn, DateTime checkOut)
        {
            return TotalRoomsPerType.Keys.Any(type => IsRoomTypeAvailable(type, checkIn, checkOut));
        }
    }
}
