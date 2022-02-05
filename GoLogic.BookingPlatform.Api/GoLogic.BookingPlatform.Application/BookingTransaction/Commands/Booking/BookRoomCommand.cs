using AutoMapper;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking
{
    public class BookRoomCommand : IRequest
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int NumberOfGuest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }

    public class BookRoomCommandHandler : IRequestHandler<BookRoomCommand>
    {
        private readonly IBookingServiceFacade _bookingService;

        public BookRoomCommandHandler(IBookingServiceFacade bookingRepository)
        {
            _bookingService = bookingRepository;
        }

        public async Task<Unit> Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookingService.BookRoom(request);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
