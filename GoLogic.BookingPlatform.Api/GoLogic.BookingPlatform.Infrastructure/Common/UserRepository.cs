using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Entities;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Infrastructure.Common
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingContext _bookingContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(BookingContext bookingContext, ILogger<UserRepository> logger)
        {
            _bookingContext = bookingContext;
            _logger = logger;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await Task.FromResult(_bookingContext.Users.FirstOrDefault(u => u.Email == email));
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerUserProcessException, ex));
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerUserProcessException, ex));
                throw;
            }
        }
    }
}
