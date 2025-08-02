using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal class BookingManager
    {
        private const int STANDARD_TOTAL_ROOMS = 5;
        private const int DELUXE_TOTAL_ROOMS = 7;
        private const int SUITE_TOTAL_ROOMS = 4;
        private const int FAMILY_TOTAL_ROOMS = 5;
        public static List<Booking> Bookings { get; } = new List<Booking>();

        public static readonly Dictionary<RoomType, int> TotalRoomsPerType = new()
        {
            { RoomType.Standard, STANDARD_TOTAL_ROOMS },
            { RoomType.Deluxe, DELUXE_TOTAL_ROOMS },
            { RoomType.Suite, SUITE_TOTAL_ROOMS },
            { RoomType.Family, FAMILY_TOTAL_ROOMS }
        };


        public static void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }

        public static List<Booking> GetAllBookings()
        {
            return Bookings;
        }

        public static IEnumerable<Booking> GetBookingsForWeek(DateTime targetDate)
        {
            // Get start (Monday) and end (Sunday)
            int daysSinceMonday = ((int)targetDate.DayOfWeek + 6) % 7;
            DateTime weekStart = targetDate.AddDays(-daysSinceMonday); // Monday
            DateTime weekEnd = weekStart.AddDays(6); // Sunday

            return Bookings.Where(b =>
                b.CheckInDate.Date >= weekStart && b.CheckInDate.Date <= weekEnd ||
                b.CheckOutDate.Date >= weekStart && b.CheckOutDate.Date <= weekEnd
            );
        }

        public static bool AreRoomsAvailable(List<Room> requestedRooms, DateTime checkIn, DateTime checkOut, int? excludeBookingId = null)
        {
            // Clone room inventory
            Dictionary<RoomType, int> availableRooms = new(TotalRoomsPerType);

            var overlappingBookings = GetAllBookings()
                .Where(b =>
                    !(b.CheckOutDate <= checkIn || b.CheckInDate >= checkOut) &&
                    (!excludeBookingId.HasValue || b.BookingId != excludeBookingId.Value) //when updating an existing booking, avoid same booking
                );

            //// Subtract existing bookings from available stock
            //foreach (var booking in overlappingBookings)
            //{
            //    foreach (var room in booking.Rooms)
            //    {
            //        if (availableRooms.ContainsKey(room.RoomType))
            //            availableRooms[room.RoomType] -= room.RoomCount;
            //    }
            //}

            // Check if all requested rooms are available
            foreach (var request in requestedRooms)
            {
                if (!availableRooms.ContainsKey(request.RoomType) || availableRooms[request.RoomType] < request.RoomCount)
                    return false;
            }

            return true;
        }


    }
}
