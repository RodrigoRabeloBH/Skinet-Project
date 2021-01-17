using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Skinet.Model;
using Skinet.Model.OrderAggregate;

namespace Skinet.Data
{
    public class SkinetSeedData
    {
        private static string path = "../Skinet.Data/SeedData/";
        public static async Task SeedAsync(SkinetContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrand.Any())
                {
                    var brandsData = File.ReadAllText(path + "brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrand.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductType.Any())
                {
                    var typesData = File.ReadAllText(path + "types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductType.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.TierPrice.Any())
                {
                    var tierpricesData = File.ReadAllText(path + "tierprice.json");

                    var tierprices = JsonSerializer.Deserialize<List<TierPrice>>(tierpricesData);

                    foreach (var tierprice in tierprices)
                    {
                        context.TierPrice.Add(tierprice);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethod.Any())
                {
                    var dmData = File.ReadAllText(path + "delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethod.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Product.Any())
                {
                    var productsData = File.ReadAllText(path + "products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Product.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SkinetContext>();

                logger.LogError(ex.InnerException.Message);
            }
        }
    }
}