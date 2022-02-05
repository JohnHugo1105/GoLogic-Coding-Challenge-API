using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Application.Common.Dtos
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public RoomDto Room { get; set; }
        public int RoomId { get; set; }
        public int NumberOfGuest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
