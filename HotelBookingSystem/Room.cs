using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    internal enum RoomType
    {
        SingleRoom,
        DoubleRoom,
        TripleRoom
    }
    
    internal class Room
    {
        public Enum RoomType { get; set; }
    }
}
