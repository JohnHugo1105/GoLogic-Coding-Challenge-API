using FluentValidation;
using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Application.BookingTransaction.Commands
{
    public class BookRoomCommandValidator : AbstractValidator<BookRoomCommand>
    {
        public BookRoomCommandValidator()
        {
            RuleFor(v => v.RoomId).NotNull();
            RuleFor(v => v.RoomId).NotEmpty();
            RuleFor(v => v.Email).NotNull();
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.NumberOfGuest).NotNull();
            RuleFor(v => v.NumberOfGuest).NotEmpty();
            RuleFor(v => v.CheckInDate).NotNull();
            RuleFor(v => v.CheckInDate).NotEmpty();
            RuleFor(v => v.CheckOutDate).NotNull();
            RuleFor(v => v.CheckOutDate).NotEmpty();
            RuleFor(v => v.CheckInDate).LessThanOrEqualTo(v => v.CheckOutDate);            
        }
    }
}
