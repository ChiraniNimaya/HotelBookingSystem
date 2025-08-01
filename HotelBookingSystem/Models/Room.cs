﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    
    public enum RoomType
    {
        Standard,
        Deluxe,
        Suite,
        Family
    }
    
    public class Room
    {
        public int RoomId { get; set; }
        public RoomType RoomType { get; set; }

        //Delete
        public int RoomCount { get; set; }
    }
}
