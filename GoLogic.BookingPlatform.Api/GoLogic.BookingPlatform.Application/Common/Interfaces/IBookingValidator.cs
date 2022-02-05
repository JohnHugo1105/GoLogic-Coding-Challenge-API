using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.Common.Interfaces
{
    public interface IBookingValidator
    {
        Task ValidateBooking(BookRoomCommand booking, IQueryable<Room> rooms, IQueryable<Booking> bookings);
    }
}
