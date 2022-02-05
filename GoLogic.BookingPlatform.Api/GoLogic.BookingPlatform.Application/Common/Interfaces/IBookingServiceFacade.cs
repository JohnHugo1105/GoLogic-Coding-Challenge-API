using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.Common.Interfaces
{
    public interface IBookingServiceFacade
    {
        Task BookRoom(BookRoomCommand booking);
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto> GetRoomById(int id);
        //Task<User> GetUserByEmail(string email);
    }
}
