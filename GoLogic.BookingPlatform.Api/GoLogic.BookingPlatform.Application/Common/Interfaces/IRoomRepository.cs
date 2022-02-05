using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.Common.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto> GetRoomById(int id);
    }
}
