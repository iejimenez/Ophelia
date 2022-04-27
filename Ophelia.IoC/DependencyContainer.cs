using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ophelia.Entities.Interfaces;
using Ophelia.Presenters;
using Ophelia.Repositories.EFCore.DataContext;
using Ophelia.Repositories.EFCore.Repositories;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCases.CustomerCases;
using Ophelia.UseCases.OrderCases;
using Ophelia.UseCasesPorts;
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
            //InputPorts-Interactors
            services.AddScoped<ICreateCustomerInputPort, CreateCustomerInteractor>();
            services.AddScoped<IGetCustomerInputPort, GetCustomersInteractor>();


            //OuputPorts-Presenters
            services.AddScoped<ICreateCustomerOutputPort, CreateCustomerPresenter>();
            services.AddScoped<IGetCustomerOutputPort, GetCustomerPresenter>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
 
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateCustomerValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateProductValidator).Assembly);
            return services;
        }
    }
}
