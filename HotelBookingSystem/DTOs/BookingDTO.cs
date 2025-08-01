﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.DTOs
{
    public class BookingDTO
    {
        public int? BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsRecurring { get; set; }
        public string? SpecialRequests { get; set; }
        public int GuestId { get; set; }
        public Dictionary<RoomType, int> RoomInfo { get; set; }
        public List<int>? RoomIds { get; set; }
        public float TotalPrice { get; set; }

        public GuestDTO GuestDto { get; set; }
    }

}
