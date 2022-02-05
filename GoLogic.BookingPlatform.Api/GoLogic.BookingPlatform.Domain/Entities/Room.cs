using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }        
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int RoomCapacity { get; set; }
        public virtual IEnumerable<RoomImage> RoomImages { get; set; }
    }
}
