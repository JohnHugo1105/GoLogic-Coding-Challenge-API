using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Infrastructure.Common;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
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
    public class BookingRepositoryTests : InMemoryDbConfigTests
    {
        private IBookingRepository _bookingRepository;
        private Mock<ILogger<BookingRepository>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<BookingRepository>>();
            _bookingRepository = new BookingRepository(_bookingContext, _mockLogger.Object);
        }

        [Test]
        public async Task BookRoom_BookSelectedRoom_AddToRoomList()
        {
            var listRooms = _bookingContext.Bookings.ToList().Count;
            var booking = new Booking
            {
                RoomId = 1,
                UserId = 1,
                NumberOfGuest = 2,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2)
            };

           await _bookingRepository.BookRoom(booking);
            var newListRoomsCount = _bookingContext.Bookings.ToList().Count;
                
            Assert.Greater(newListRoomsCount, listRooms);
        }
    }
}
