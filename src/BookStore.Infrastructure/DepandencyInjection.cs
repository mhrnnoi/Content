using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Infrastructure.Persistence;
using BookStore.Infrastructure.Persistence.DataContext;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class DepandencyInjection
    {
        public static IServiceCollection AddInfruscture(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(cfg =>
            {
                cfg.UseNpgsql(connectionString);
            });

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}