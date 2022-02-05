using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Domain.Constants
{
    public static class ExceptionMsgs
    {

        public const string LoggerGeneralException = "General exception. see details: {0}";

        public const string LoggerBookingValidationException = "Booking validation error. See details: {0}";
        public const string LoggerBookingProcessException = "Booking process error. See details: {0}";

        public const string MaxRoomCapacityReachedMsg = "Max room capacity reached";
        public const string RoomHasAlreadyBeenBookedMsg = " The selected dates has already been booked. Please select a different dates";
        public const string InvalidEmailMsg = "Email provided is invalid or does not exist";

        public const string LoggerRoomProcessException = "Room process error. See details: {0}";

        public const string LoggerUserProcessException = "User process error. See details: {0}";
    }
}
