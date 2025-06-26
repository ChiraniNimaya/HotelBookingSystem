using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal class BookingService
    {
        private static List<Booking> bookings = new();

        public static void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public static List<Booking> GetWeeklyReport(DateTime weekStart)
        {
            return bookings.Where(booking =>
                booking.CheckInDate >= weekStart && booking.CheckInDate < weekStart.AddDays(7)).ToList();
        }
    }
}
