using AutoMapper;
using back_end.Models;
using back_end.DTOs;
using back_end.Models;
using back_end.DTOs.ProductDtos;
using PerfumeShop.DTOs.Product;

public class ProductMP : Profile
{
    public ProductMP()
    {
        CreateMap<Product, ProductDetailDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductCreateDto>();
        CreateMap<Product, ProductListDto>();
        CreateMap<ProductUpdateDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}