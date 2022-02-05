using AutoMapper;
using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.Common.Dtos;
using GoLogic.BookingPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookRoomCommand, Booking>();
            CreateMap<Address, AddressDto>();
            CreateMap<RoomImage, RoomImageDto>();
            CreateMap<Room, RoomDto>();
        }
    }
}
