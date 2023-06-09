using AutoMapper;
using Cart_API.Data.Dtos;
using Cart_API.Models;

namespace Cart_API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
