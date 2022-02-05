using AutoMapper;
using GoLogic.BookingPlatform.Application.BookingTransaction.Commands;
using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Infrastructure.Common
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _bookingContext;
        private readonly ILogger<BookingRepository> _logger;

        public BookingRepository(BookingContext bookingContext, ILogger<BookingRepository> logger)
        {
            _bookingContext = bookingContext;
            _logger = logger;
        }

        public async Task BookRoom(Booking booking)
        {
            try
            {
                _bookingContext.Add(booking);
                await _bookingContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerBookingProcessException, ex));
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerBookingProcessException, ex));
                throw;
            }           
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerBookingProcessException, ex));
                throw;
            }
        }
    }
}
