using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Infrastructure.UnitTests.Common
{
    public class InMemoryDbConfigTests : IDisposable
    {
        protected BookingContext _bookingContext;
        public InMemoryDbConfigTests()
        {
            var options = new DbContextOptionsBuilder<BookingContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            _bookingContext = new BookingContext(options);

            _bookingContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _bookingContext.Database.EnsureDeleted();
            _bookingContext.Dispose();
        }
    }
}
