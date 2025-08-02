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

        public static float CalculateSeasonalMultiplier(DateTime date)
        {
            int month = date.Month;

            //Holidays (December)
            if (month == 12) return 1.25f;

            // Peak season (Jan-March)
            if (month == 1 || month == 2 || month == 3) return 1.2f;

            //Mid season (August)
            if (month == 8) return 1.15f;

            // Pre Peak seasons (September, November)
            if (month == 5 || month == 6) return 1.1f;

            // Rainy season (May-June)
            if (month == 5 || month == 6) return 0.9f;

            // Low season (April, July, October)
            return 1.0f;
        }

        public static float CalculateRoomRate(RoomType type, DateTime date, bool isResident)
        {

            float guestMultiplier = isResident ? 0.8f : 1.0f;
            float seasonalMultiplier = CalculateSeasonalMultiplier(date);

            return RoomRate[type] * guestMultiplier * seasonalMultiplier;
        }
        public static void UpdateTotalBookingPrice(Booking booking)
        {
            float total = 0f;

            //for (DateTime day = booking.CheckInDate; day < booking.CheckOutDate; day = day.AddDays(1))
            //{
            //    foreach (var room in booking.Rooms)
            //    {
            //        float dailyPrice = CalculateRoomRate(room.RoomType, day, booking.Guest.IsResident);
            //        total += dailyPrice * room.RoomCount;
            //    }
            //}

            booking.TotalPrice = total;
        }
    }
}
