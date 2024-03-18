using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrl : IValueResolver<Product, ProductsToReturn, string>
    {
        private readonly IConfiguration _config;

        public ProductUrl(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductsToReturn destination,
        string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}