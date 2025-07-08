using System;
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
        public RoomType RoomType { get; set; }
        public int NumberOfRooms { get; set; } = 0;


    }
}
