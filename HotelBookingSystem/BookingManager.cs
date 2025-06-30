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
    }
}
