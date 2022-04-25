using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ophelia.Entities.Interfaces;
using Ophelia.Repositories.EFCore.DataContext;
using Ophelia.Repositories.EFCore.Repositories;
using Ophelia.UseCases.Common.Behaviors;
using Ophelia.UseCases.OrderCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddOpheliaServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpheliaContext>(options => options.UseSqlServer(configuration.GetConnectionString("OpheliaDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Order
            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
