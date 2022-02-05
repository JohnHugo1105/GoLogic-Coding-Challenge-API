using AutoMapper;
using GoLogic.BookingPlatform.Application.Common.Dtos;
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
    [TestFixture]
    public class RoomRepositoryTests : InMemoryDbConfigTests
    {
        private IRoomRepository _roomRepository;
        private Mock<ILogger<RoomRepository>> _mockLogger;

        private static IMapper _mapper;

        public RoomRepositoryTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile.MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<RoomRepository>>();
            _roomRepository = new RoomRepository(_bookingContext, _mockLogger.Object, _mapper);
        }

        [Test]
        public async Task GetRooms_WhenCalled_ReturnsListOfRooms()
        {
            var rooms = await _roomRepository.GetRooms();

            Assert.AreEqual(5, rooms.Count());
        }

        [Test]
        public async Task GetRooms_ShouldHaveListOfRoomsWithImages()
        {
            var rooms = await Task.FromResult(_roomRepository.GetRooms().Result.ToList());
            var hasImages = rooms.Any(r => r.RoomImages != null || r.RoomImages.Count() > 0);

            Assert.IsTrue(hasImages);
        }       

        [Test]
        public async Task GetRoomById_WhenRoomSelected_ReturnsRoomDetails()
        {
            var room = await _roomRepository.GetRoomById(1);

            Assert.IsNotNull(room);
        }
    }
}
