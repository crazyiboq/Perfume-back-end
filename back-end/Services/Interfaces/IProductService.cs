using back_end.DTOs.ProductDtos;
using back_end.Helpers;
using PerfumeShop.DTOs.Product;

namespace PerfumeShopApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductListDto>> GetAllAsync(ProductQueryParams qp);
        Task<ProductDetailDto?> GetByIdAsync(int id);
        Task<ProductDetailDto> CreateAsync(ProductCreateDto dto);
        Task<ProductDetailDto?> UpdateAsync(int id, ProductUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductListDto>> GetFeaturedAsync(int count = 10);
        Task<IEnumerable<ProductListDto>> GetByCategoryAsync(int categoryId, int limit = 50);
        Task<IEnumerable<ProductListDto>> SearchAsync(string query, int limit = 20);
       
    }
}