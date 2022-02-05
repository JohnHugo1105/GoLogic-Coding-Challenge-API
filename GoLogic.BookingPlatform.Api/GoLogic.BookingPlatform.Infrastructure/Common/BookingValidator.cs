using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Domain.Exceptions;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Infrastructure.Common
{
    public class BookingValidator : IBookingValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<BookingValidator> _logger;

        public BookingValidator(IUserRepository userRepository, ILogger<BookingValidator> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task ValidateBooking(BookRoomCommand booking, IQueryable<Room> rooms, IQueryable<Booking> bookings)
        {
            try
            {                
                await ValidateRoomCapacity(booking, rooms);
                await ValidateRoomAvailability(booking, bookings);
                await ValidateUserEmail(booking.Email);
            }
            catch (BookingValidationException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerBookingValidationException, ex));
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task ValidateRoomCapacity(BookRoomCommand booking, IQueryable<Room> rooms)
        {
            try
            {
                var room = await rooms.Where(r => r.Id == booking.RoomId)
                                      .SingleOrDefaultAsync(r => r.RoomCapacity >= booking.NumberOfGuest);

                if (room == null)
                    throw new BookingValidationException(ExceptionMsgs.MaxRoomCapacityReachedMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ValidateRoomAvailability(BookRoomCommand booking, IQueryable<Booking> bookings)
        {
            try
            {
                //used explicit for each due to LINQ intermitent behavior on Date data type
                var queriedBookings = await bookings.Where(b => b.RoomId == booking.RoomId).ToListAsync();

                foreach (var item in queriedBookings)
                {
                    if (item.CheckInDate.Equals(booking.CheckInDate) && item.CheckOutDate.Equals(booking.CheckOutDate))
                        throw new BookingValidationException(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg);

                    if (item.CheckInDate.Equals(booking.CheckInDate) || item.CheckOutDate.Equals(booking.CheckOutDate))
                        throw new BookingValidationException(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg);

                    if (booking.CheckInDate > booking.CheckOutDate)
                        throw new BookingValidationException(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg);

                    if ((booking.CheckInDate >= item.CheckInDate && booking.CheckInDate <= item.CheckOutDate) || booking.CheckOutDate > item.CheckInDate && booking.CheckOutDate <= item.CheckOutDate)
                        throw new BookingValidationException(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg);

                    if(booking.CheckInDate <= item.CheckInDate && booking.CheckOutDate > item.CheckInDate)
                        throw new BookingValidationException(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg);
                }         
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ValidateUserEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);

                if (user == null)
                    throw new BookingValidationException(ExceptionMsgs.InvalidEmailMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
