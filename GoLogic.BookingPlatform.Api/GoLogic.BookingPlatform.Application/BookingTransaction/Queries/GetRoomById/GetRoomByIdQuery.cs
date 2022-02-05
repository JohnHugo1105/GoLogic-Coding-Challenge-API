using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.BookingTransaction.Queries.GetRoomById
{
    public class GetRoomByIdQuery : IRequest<RoomDto>
    {
        public int RoomdId { get; set; }
    }

    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly IBookingServiceFacade _bookingService;

        public GetRoomByIdQueryHandler(IBookingServiceFacade roomRepository)
        {
            _bookingService = roomRepository;
        }

        public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bookingService.GetRoomById(request.RoomdId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
