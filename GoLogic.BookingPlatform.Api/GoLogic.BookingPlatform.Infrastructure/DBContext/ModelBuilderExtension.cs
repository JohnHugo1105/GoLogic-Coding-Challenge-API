using GoLogic.BookingPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoLogic.BookingPlatform.Infrastructure.DBContext
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Room>()
                   .Property(r => r.Price)
                   .HasColumnType("decimal(19,2)");

            builder.Entity<RoomImage>()
                   .HasOne(a => a.Room)
                   .WithMany(b => b.RoomImages);

            builder.Entity<Address>()
                    .HasData(
                    new List<Address>
                    {
                        new Address
                        {
                          AddressId = 1,
                           Country = "Australia" ,
                           City = "Melbourne",
                           PostalCode = 3000,
                           State = "Victoria"
                        },
                        new Address
                        {
                          AddressId = 2,
                           Country = "Australia" ,
                           City = "Morpeth",
                           PostalCode = 2321,
                           State = "New South Wales"
                        },
                        new Address
                        {
                          AddressId = 3,
                           Country = "Australia" ,
                           City = "Smithton",
                           PostalCode = 7330,
                           State = "Tasmania"
                        },
                        new Address
                        {
                          AddressId = 4,
                           Country = "Australia" ,
                           City = "Cannonvale",
                           PostalCode = 4802,
                           State = "Queensland"
                        },
                        new Address
                        {
                          AddressId = 5,
                           Country = "Australia" ,
                           City = "Kurmond",
                           PostalCode = 2754,
                           State = "New South Wales"
                        },
                    }
                );


            builder.Entity<Room>()
                   .HasData(
                   new List<Room> {
                        new Room
                        {
                           Id = 1,
                           Title = "Oaks Melbourne on Lonsdale Suites",
                           Description = "Oaks Melbourne on Lonsdale Suites is surrounded by fabulous shopping, restaurants, cafés, the vibrant theater district and Chinatown. The iconic MCG and Rod Laver Arena are each a 20-minute walk away.",
                           AddressId = 1,
                           RoomCapacity = 2,
                           Price = 136.30M
                        },
                        new Room
                        {
                           Id = 2,
                           Title = "Hunter Oasis",
                           Description = "Hunter Oasis has an outdoor swimming pool, fitness center, a shared lounge and garden in Morpeth. Among the facilities at this property are a 24-hour front desk and a shared kitchen, along with free WiFi throughout the property. The motel features family rooms.",
                           AddressId = 2,
                           RoomCapacity = 5,
                           Price = 120
                        },
                        new Room
                        {
                           Id = 3,
                           Title = "Bridge Hotel",
                           Description = "Bridge Hotel has a restaurant, bar, a shared lounge and garden in Smithton. The property has a shared kitchen and room service for guests.",
                           AddressId = 3,
                           RoomCapacity = 3,
                           Price = 152.30M
                        },
                        new Room
                        {
                           Id = 4,
                           Title = "Airlie Beach Eco Cabins",
                           Description = "Located in Cannonvale, 6.1 mi from Airlie Beach, this property offers a unique wildlife experience in a tranquil Australian bush setting. Airlie Beach Eco Cabins features accommodations with free WiFi and is 2.6 mi from Whitsunday Plaza.",
                           AddressId = 4,
                           RoomCapacity = 2,
                           Price = 146.10M
                        },
                        new Room
                        {
                           Id = 5,
                           Title = "A place to be",
                           Description = "Featuring air-conditioned accommodations with a balcony, A place to be is located in Kurmond. The property is 45.1 km from Liverpool and free private parking is featured.",
                           AddressId = 5,
                           RoomCapacity = 3,
                           Price = 176.80M
                        },
                   }
                );

            builder.Entity<RoomImage>()
                   .HasData(
                    new List<RoomImage> {
                        new RoomImage
                        {
                           Id = 1,
                           ImageName = "RoomA1.jpg",
                           RoomId = 1
                        },
                        new RoomImage
                        {
                            Id = 2,
                           ImageName = "RoomA2.jpg",
                           RoomId = 1
                        },
                        new RoomImage
                        {
                            Id = 3,
                           ImageName = "RoomA3.jpg",
                           RoomId = 1
                        },
                        new RoomImage
                        {
                            Id = 4,
                           ImageName = "RoomB1.jpg",
                           RoomId = 2
                        },
                        new RoomImage
                        {
                            Id = 5,
                           ImageName = "RoomB2.jpg",
                           RoomId = 2
                        },
                        new RoomImage
                        {
                            Id = 6,
                           ImageName = "RoomB3.jpg",
                           RoomId = 2
                        },
                        new RoomImage
                        {
                            Id = 7,
                           ImageName = "RoomC1.jpg",
                           RoomId = 3
                        },
                        new RoomImage
                        {
                            Id = 8,
                           ImageName = "RoomC2.jpg",
                           RoomId = 3
                        },
                        new RoomImage
                        {
                            Id = 9,
                           ImageName = "RoomC3.jpg",
                           RoomId = 3
                        },
                        new RoomImage
                        {
                            Id = 10,
                           ImageName = "RoomD1.jpg",
                           RoomId = 4
                        },
                        new RoomImage
                        {
                            Id = 11,
                           ImageName = "RoomD2.jpg",
                           RoomId = 4
                        },
                        new RoomImage
                        {
                            Id = 12,
                           ImageName = "RoomD3.jpg",
                           RoomId = 4
                        },
                        new RoomImage
                        {
                            Id = 13,
                           ImageName = "RoomE1.jpg",
                           RoomId = 5
                        },
                        new RoomImage
                        {
                            Id = 14,
                           ImageName = "RoomE2.jpg",
                           RoomId = 5
                        },
                        new RoomImage
                        {
                            Id = 15,
                           ImageName = "RoomE3.jpg",
                           RoomId = 5
                        },
                    }
                );

            builder.Entity<User>()
                   .HasData(
                    new List<User> {
                        new User
                        {
                           UserId = 1,
                           Name = "John Thompson",
                           Email = "user@gmail.com",
                           Password = "12345"
                        }
                    }
                );
        }
    }
}
