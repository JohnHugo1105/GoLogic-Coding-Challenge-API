using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Domain.Entities
{
    public class RoomImage
    {        
        public int Id { get; set; }
        public string ImageName { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
