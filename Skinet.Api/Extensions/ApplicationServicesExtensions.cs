using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skinet.Api.Errors;
using Skinet.Data;
using Skinet.Data.Repositoty;
using Skinet.Service;
using Skinet.Service.Interfaces;
using StackExchange.Redis;

namespace Skinet.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            services.AddScoped<IProductBrandRepository, ProductBrandRepository>();

            services.AddScoped<ITierPriceRepository, TierPriceRepository>();

            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<ITokenServices, TokenService>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IDeliveryMethodRepository, DeliveryMethodRepository>();

            services.AddScoped<IShippingAddressRepository, ShippingAddressRepository>();

            services.AddScoped<IBasketServices, BasketServices>();

            services.AddSingleton<IConnectionMultiplexer>(c =>
                {
                    var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);

                    return ConnectionMultiplexer.Connect(config);
                });

            services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState
                            .Where(e => e.Value.Errors.Count > 0)
                            .SelectMany(x => x.Value.Errors)
                            .Select(x => x.ErrorMessage).ToArray();

                        var errorResponse = new ApiValidationResponse
                        {
                            Errors = errors
                        };
                        return new BadRequestObjectResult(errorResponse);
                    };
                });

            return services;
        }
    }
}