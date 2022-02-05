using GoLogic.BookingPlatform.Application.BookingTransaction.Commands;
using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Application.Common.Interfaces
{
    public interface IBookingRepository
    {        
        Task BookRoom(Booking booking);
    }
}
