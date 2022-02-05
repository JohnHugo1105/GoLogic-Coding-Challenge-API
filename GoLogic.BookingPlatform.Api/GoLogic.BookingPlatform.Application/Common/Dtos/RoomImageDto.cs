using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Application.Common.Dtos
{
    public class RoomImageDto
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public RoomDto Room { get; set; }
        public int RoomId { get; set; }
    }
}
