using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Application.Common.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AddressDto Address { get; set; }
        public int AddressId { get; set; }
        public int RoomCapacity { get; set; }
        public virtual IEnumerable<RoomImageDto> RoomImages { get; set; }
    }
}
