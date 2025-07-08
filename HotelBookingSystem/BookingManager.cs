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
            { RoomType.Standard, 1 },
            { RoomType.Deluxe, 7 },
            { RoomType.Suite, 4 },
            { RoomType.Family, 5 }
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

        public static bool AreRoomsAvailable(List<Room> requestedRooms, DateTime checkIn, DateTime checkOut, int? excludeBookingId = null)
        {
            // Clone room inventory
            Dictionary<RoomType, int> availableRooms = new(TotalRoomsPerType);

            var overlappingBookings = GetAllBookings()
                .Where(b =>
                    !(b.CheckOutDate <= checkIn || b.CheckInDate >= checkOut) &&
                    (!excludeBookingId.HasValue || b.BookingId != excludeBookingId.Value)
                );

            // Subtract existing bookings from available stock
            foreach (var booking in overlappingBookings)
            {
                foreach (var room in booking.Rooms)
                {
                    if (availableRooms.ContainsKey(room.RoomType))
                        availableRooms[room.RoomType] -= room.NumberOfRooms;
                }
            }

            // Check if all requested rooms are available
            foreach (var request in requestedRooms)
            {
                if (!availableRooms.ContainsKey(request.RoomType) || availableRooms[request.RoomType] < request.NumberOfRooms)
                    return false;
            }

            return true;
        }


    }
}
