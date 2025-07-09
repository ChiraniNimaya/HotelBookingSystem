using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public static class PricingManager
    {
        private const float STANDARD_BASE_PRICE = 8000f;
        private const float DELUXE_BASE_PRICE = 12000f;
        private const float SUITE_BASE_PRICE = 18000f;
        private const float FAMILY_BASE_PRICE = 15000f;

        public static readonly Dictionary<RoomType, float> RoomRate = new()
        {
            { RoomType.Standard, STANDARD_BASE_PRICE },
            { RoomType.Deluxe, DELUXE_BASE_PRICE },
            { RoomType.Suite, SUITE_BASE_PRICE },
            { RoomType.Family, FAMILY_BASE_PRICE }
        };
        public static float CalculateRoomRate(RoomType type, DateTime date, bool isResident)
        {

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

            return RoomRate[type] * multiplier;
        }
        public static void UpdateTotalBookingPrice(Booking booking)
        {
            float total = 0f;

            for (DateTime day = booking.CheckInDate; day < booking.CheckOutDate; day = day.AddDays(1))
            {
                foreach (var room in booking.Rooms)
                {
                    float dailyPrice = CalculateRoomRate(room.RoomType, day, booking.Guest.IsResident);
                    total += dailyPrice * room.NumberOfRooms;
                }
            }

            booking.TotalPrice = total;
        }
    }
}
