using AutoMapper;
using Microsoft.Extensions.Configuration;
using Skinet.Api.Dto;
using Skinet.Model;

namespace Skinet.Api.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + "images/products/" + source.ImageUrl;
            }
            return null;
        }
    }
}