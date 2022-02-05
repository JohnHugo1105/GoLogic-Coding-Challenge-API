using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Domain.Enums
{
    public enum BookingExceptionEnum
    {
        MaxRoomCapacityReached = 0,
        RoomHasAlreadyBeenBooked = 1,
        InvalidEmail = 2,
        All = 3
    }
}
