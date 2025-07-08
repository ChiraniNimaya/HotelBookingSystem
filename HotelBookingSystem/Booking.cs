using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        private const float STANDARD_BASE_PRICE = 8000;
        private const float DELUXE_BASE_PRICE = 12000;
        private const float SUITE_BASE_PRICE = 18000;
        private const float FAMILY_BASE_PRICE = 15000;

        private static int s_lastBookingId = 0;
        public Guest Guest { get; set; }
        public int BookingId { get; private set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string SpecialRequests { get; set; }
        public List<Room> Rooms { get; } = new List<Room>();
        public float TotalPrice { get; set; }

        public Booking(Guest guest, DateTime checkIn, DateTime checkOut, bool isRecurring, string specialRequests, List<Room> rooms)
        {
            BookingId = ++s_lastBookingId; // Auto-incrementing ID
            Guest = guest;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            IsRecurring = isRecurring;
            SpecialRequests = specialRequests;
            Rooms = rooms;
        }

        public float CalculateRoomRate(RoomType type, DateTime date, bool isResident)
        {
            float basePrice = type switch
            {
                RoomType.Standard => STANDARD_BASE_PRICE,
                RoomType.Deluxe => DELUXE_BASE_PRICE,
                RoomType.Suite => SUITE_BASE_PRICE,
                RoomType.Family => FAMILY_BASE_PRICE,
                _ => 0
            };

            float multiplier = 1.0f;

            // Holiday list (2025 Sri Lanka)
            var holidays = new HashSet<DateTime>
            {
                new DateTime(2025, 1, 15),  // Thai Pongal
                new DateTime(2025, 2, 4),   // Independence Day
                new DateTime(2025, 3, 7),   // Maha Shivaratri
                new DateTime(2025, 4, 13),  // Sinhala New Year Eve
                new DateTime(2025, 4, 14),  // Sinhala New Year
                new DateTime(2025, 5, 1),   // Labour Day
                new DateTime(2025, 5, 10),  // Vesak
                new DateTime(2025, 6, 18),  // Poson
                new DateTime(2025, 7, 10),  // Esala
            };

            bool isHoliday = holidays.Contains(date.Date);
            bool isPeak = date.Month >= 1 && date.Month <= 3;
            bool isRainy = date.Month >= 5 && date.Month <= 6;

            // Apply season-based adjustments
            if (isPeak)
                multiplier += isResident ? 0.05f : 0.2f;
            if (isRainy)
                multiplier += isResident ? -0.2f : -0.1f;
            if (isHoliday)
                multiplier += isResident ? 0.15f : 0.3f;

            // Resident discount on base
            if (isResident)
                multiplier -= 0.15f; // Base discount

            return basePrice * multiplier;
        }
        public void CalculateTotalBookingPrice()
        {
            float total = 0f;

            for (DateTime day = CheckInDate; day < CheckOutDate; day = day.AddDays(1))
            {
                foreach (var room in Rooms)
                {
                    float dailyPrice = CalculateRoomRate(room.RoomType, day, Guest.IsResident);
                    total += dailyPrice * room.NumberOfRooms;
                }
            }

            TotalPrice = total;
        }
    }
}
