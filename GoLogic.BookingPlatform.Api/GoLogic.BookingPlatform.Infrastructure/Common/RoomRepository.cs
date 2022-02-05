using AutoMapper;
using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Entities;
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
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingContext _bookingContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomRepository> _logger;

        public RoomRepository(BookingContext bookingContext, ILogger<RoomRepository> logger, IMapper mapper)
        {
            _bookingContext = bookingContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<RoomDto> GetRoomById(int id)
        {
            try
            {
                var roomInDb = await _bookingContext.Rooms.Include(r => r.Address)
                                                  .Include(r => r.RoomImages)
                                                  .SingleOrDefaultAsync(r => r.Id == id);

                var room = _mapper.Map<RoomDto>(roomInDb);

                return room;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerRoomProcessException, ex)); 
                throw;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerRoomProcessException, ex));
                throw; ;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerRoomProcessException, ex));
                throw;
            }
        }

        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            try
            {
                var roomsInDb = await _bookingContext.Rooms.Include(r => r.Address)
                                                  .Include(r => r.RoomImages)
                                                  .ToListAsync();

                var rooms = _mapper.Map<List<RoomDto>>(roomsInDb);

                return rooms;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerRoomProcessException, ex));
                throw;
            }
        }
    }
}
