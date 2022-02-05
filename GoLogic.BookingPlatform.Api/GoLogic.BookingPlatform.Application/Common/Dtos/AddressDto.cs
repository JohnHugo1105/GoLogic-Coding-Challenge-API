using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Application.Common.Dtos
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long PostalCode { get; set; }
    }
}
