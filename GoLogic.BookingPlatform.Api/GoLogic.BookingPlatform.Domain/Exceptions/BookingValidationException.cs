using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Domain.Exceptions
{
    public class BookingValidationException : Exception
    {
        public BookingValidationException(string message)
            : base(message)
        {

        }
    }
}
