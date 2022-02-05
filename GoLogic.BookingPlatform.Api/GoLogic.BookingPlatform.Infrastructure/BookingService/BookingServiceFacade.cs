using AutoMapper;
using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Infrastructure.BookingService
{
    public class BookingServiceFacade : IBookingServiceFacade
    {
        private readonly BookingContext _bookingContext;
        private readonly IBookingValidator _bookingValidator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ILogger<BookingServiceFacade> _logger;

        public BookingServiceFacade(BookingContext bookingContext, IBookingValidator bookingValidator, IMapper mapper, IUserRepository userRepository, IBookingRepository bookingRepository, IRoomRepository roomRepository, ILogger<BookingServiceFacade> logger)
        {
            _bookingContext = bookingContext;
            _bookingValidator = bookingValidator;
            _mapper = mapper;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _logger = logger;
        }

        public async Task BookRoom(BookRoomCommand booking)
        {
            try
            {
                await _bookingValidator.ValidateBooking(booking, _bookingContext.Rooms, _bookingContext.Bookings);

                var bookingMapped = _mapper.Map<BookRoomCommand, Booking>(booking);                

                await _bookingRepository.BookRoom(bookingMapped);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomDto> GetRoomById(int id)
        {
            try
            {
                return await _roomRepository.GetRoomById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            try
            {               
                return await _roomRepository.GetRooms();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await _userRepository.GetUserByEmail(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
