using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.BookingTransaction.Queries.GetRoomsList
{
    public class GetRoomsQuery : IRequest<IEnumerable<RoomDto>>
    {

    }

    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, IEnumerable<RoomDto>>
    {
        private readonly IBookingServiceFacade _bookingService;

        public GetRoomsQueryHandler(IBookingServiceFacade bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bookingService.GetRooms();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
