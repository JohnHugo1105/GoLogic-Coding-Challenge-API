using GoLogic.BookingPlatform.Application.Common.Interfaces;
using GoLogic.BookingPlatform.Infrastructure.BookingService;
using GoLogic.BookingPlatform.Infrastructure.Common;
using GoLogic.BookingPlatform.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GoLogic.BookingPlatform.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer(
                        configuration.GetConnectionString("BookingContext"),
                        b => b.MigrationsAssembly(typeof(BookingContext).Assembly.FullName)));

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingValidator, BookingValidator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingServiceFacade, BookingServiceFacade>();
            
            return services;
        }
    }
}
