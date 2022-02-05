using AutoMapper;
using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Domain.Exceptions;
using GoLogic.BookingPlatform.Infrastructure.Common;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Infrastructure.UnitTests.Common
{
    public class BookingValidatorTests : InMemoryDbConfigTests
    {
        private IBookingValidator _bookingValidator;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<ILogger<BookingValidator>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<BookingValidator>>();
            _mockUserRepository = new Mock<IUserRepository>();
            
            _bookingValidator = new BookingValidator(_mockUserRepository.Object, _mockLogger.Object);
        }       

        [Test]
        public async Task ValidateBooking_RoomCapacityAndEmail_DoNotThrowException()
        {
            _mockUserRepository.Setup(u => u.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new User());

            var booking = new Booking
            {
                RoomId = 1,
                UserId = 1,
                NumberOfGuest = 2,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2)
            };

            _bookingContext.Add(booking);
            await _bookingContext.SaveChangesAsync();

            var newBooking = new BookRoomCommand
            {
                UserId = 1,
                RoomId = 1,
                NumberOfGuest = 2,
                Email = "user@gmail.com",
                CheckInDate = DateTime.Now.AddDays(-2),
                CheckOutDate = DateTime.Now.AddDays(-1)
            };

            var rooms = _bookingContext.Rooms;
            var bookings = _bookingContext.Bookings;

            Assert.DoesNotThrowAsync(async () => await _bookingValidator.ValidateBooking(newBooking, rooms, bookings));
        }


        [Test]
        [TestCase("user@gmail.com", 3, ExceptionMsgs.MaxRoomCapacityReachedMsg)]
        [TestCase("notexist@gmail.com", 2, ExceptionMsgs.InvalidEmailMsg)]
        public async Task ValidateBooking_InvalidRoomCapacityAndEmail_ThrowsException(string email, int numberOfGuest, string expectedExceptionMsg)
        {
            var booking = new Booking
            {
                RoomId = 1,
                UserId = 1,
                NumberOfGuest = 2,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2)
            };

            _bookingContext.Add(booking);
            await _bookingContext.SaveChangesAsync();

            var newBooking = new BookRoomCommand
            {
                UserId = 1,
                RoomId = 1,
                NumberOfGuest = numberOfGuest,
                Email = email,
                CheckInDate = DateTime.Now.AddDays(-2),
                CheckOutDate = DateTime.Now.AddDays(-1)
            };

            var rooms = _bookingContext.Rooms;
            var bookings = _bookingContext.Bookings;

            var ex = Assert.ThrowsAsync<BookingValidationException>( async () => await _bookingValidator.ValidateBooking(newBooking, rooms, bookings));

            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMsg));
        }


        [Test]
        [TestCase(-2, -1)]
        [TestCase(3, 4)]
        public async Task ValidateBooking_ValidDateBooking_DoNotThrowException(int checkInDays, int checkOutDays)
        {
            _mockUserRepository.Setup(u => u.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new User());

            var booking = new Booking
            {
                RoomId = 1,
                UserId = 1,
                NumberOfGuest = 2,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2)
            };


            _bookingContext.Add(booking);
            await _bookingContext.SaveChangesAsync();

            var newBooking = new BookRoomCommand
            {
                UserId = 1,
                RoomId = 1,
                NumberOfGuest = 2,
                Email = "user@gmail.com",
                CheckInDate = DateTime.Now.AddDays(checkInDays),
                CheckOutDate = DateTime.Now.AddDays(checkOutDays)
            };

            var rooms = _bookingContext.Rooms;
            var bookings = _bookingContext.Bookings;

            Assert.DoesNotThrowAsync(async () => await _bookingValidator.ValidateBooking(newBooking, rooms, bookings));
        }

        [Test]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(1, 1)]
        [TestCase(-1, 3)]
        public async Task ValidateBooking_InvalidDateBooking_ThrowsException(int checkInDays, int checkOutDays)
        {
            var booking = new Booking
            {
                RoomId = 1,
                UserId = 1,
                NumberOfGuest = 2,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2)
            };

           
            _bookingContext.Add(booking);
            await _bookingContext.SaveChangesAsync();

            var newBooking = new BookRoomCommand
            {
                UserId = 1,
                RoomId = 1,
                NumberOfGuest = 2,
                Email = "user@gmail.com",
                CheckInDate = DateTime.Now.AddDays(checkInDays),
                CheckOutDate = DateTime.Now.AddDays(checkOutDays)
            };

            var rooms = _bookingContext.Rooms;
            var bookings = _bookingContext.Bookings;
            
            var ex = Assert.ThrowsAsync<BookingValidationException>(async () => await _bookingValidator.ValidateBooking(newBooking, rooms, bookings));

            Assert.That(ex.Message, Is.EqualTo(ExceptionMsgs.RoomHasAlreadyBeenBookedMsg));
        }       
    }
}
