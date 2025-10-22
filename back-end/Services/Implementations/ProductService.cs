using AutoMapper;

using Microsoft.EntityFrameworkCore;

using back_end.Data;

using back_end.DTOs.ProductDtos;

using back_end.Helpers;

using back_end.Models;

using PerfumeShopApi.Services.Interfaces;
using PerfumeShop.DTOs.Product;


namespace PerfumeShopApi.Services

{

    public class ProductService : IProductService

    {

        private readonly AppDbContext _db;

        private readonly IMapper _mapper;

        private readonly ILogger<ProductService> _logger;
 
        public ProductService(AppDbContext db, IMapper mapper, ILogger<ProductService> logger)

        {

            _db = db;

            _mapper = mapper;

            _logger = logger;

        }
 
        public async Task<PagedResult<ProductListDto>> GetAllAsync(ProductQueryParams qp)

        {

            var query = _db.Products

                .AsNoTracking()

                .Include(p => p.Category)

                .AsQueryable();
 
            if (!string.IsNullOrWhiteSpace(qp.Search))

            {

                var s = qp.Search.Trim();

                query = query.Where(p => p.Name.Contains(s) || p.Brand.Contains(s) || p.Description.Contains(s));

            }
 
            if (qp.CategoryId.HasValue)

            {

                query = query.Where(p => p.CategoryId == qp.CategoryId.Value);

            }
 
            if (qp.MinPrice.HasValue)

            {

                query = query.Where(p => p.Price >= qp.MinPrice.Value);

            }
 
            if (qp.MaxPrice.HasValue)

            {

                query = query.Where(p => p.Price <= qp.MaxPrice.Value);

            }
 
            if (qp.InStock.HasValue)

            {

                query = query.Where(p => p.InStock == qp.InStock.Value);

            }
 


            query = qp.Sort switch

            {

                "price_asc" => query.OrderBy(p => p.Price),

                "price_desc" => query.OrderByDescending(p => p.Price),

                "newest" => query.OrderByDescending(p => p.Id), // or CreatedAt if exist

                "rating_desc" => query.OrderByDescending(p => p.Rating),

                "featured" => query.OrderByDescending(p => p.Featured).ThenByDescending(p => p.Id),

                _ => query.OrderByDescending(p => p.Featured).ThenByDescending(p => p.Id)

            };
 
            var total = await query.CountAsync();
 
            var page = Math.Max(qp.Page, 1);

            var pageSize = Math.Clamp(qp.PageSize, 1, 100);
 
            var items = await query

                .Skip((page - 1) * pageSize)

                .Take(pageSize)

                .ToListAsync();
 
            var dtoItems = _mapper.Map<List<ProductListDto>>(items);
 
            return new PagedResult<ProductListDto>

            {

                Page = page,

                PageSize = pageSize,

                TotalItems = total,

                Items = dtoItems

            };

        }
 
        public async Task<ProductDetailDto?> GetByIdAsync(int id)

        {

            var p = await _db.Products

                .AsNoTracking()

                .Include(x => x.Category)

                .FirstOrDefaultAsync(x => x.Id == id);
 
            if (p == null) return null;
 
            var dto = _mapper.Map<ProductDetailDto>(p);

            dto.AvailableVolumes ??= Array.Empty<int>();

            dto.CategoryName = p.Category?.Name;

            return dto;

        }
 
        public async Task<ProductDetailDto> CreateAsync(ProductCreateDto dto)

        {

           

            var entity = new Product

            {

                Name = dto.Name,

                Brand = dto.Brand,

                CategoryId = dto.CategoryId,

                Price = dto.Price,

                Discount = dto.Discount,

                Description = dto.Description,

                Image = dto.Image,

                InStock = dto.InStock,

                Featured = dto.Featured,

                Rating = 0m,

                Reviews = 0

            };

            Volume ToEnum(int ml) => ml switch
            {
                30 => Volume.ML30,
                50 => Volume.ML50,
                100 => Volume.ML100,
                _ => throw new ArgumentException($"Invalid volume: {ml}")
            };

            if (dto.AvailableVolumes != null)
            {
                entity.AvailableVolumes = dto.AvailableVolumes.Select(v => ToEnum(v)).ToArray();
            }

            _db.Products.Add(entity);

            await _db.SaveChangesAsync();
 
            var created = _mapper.Map<ProductDetailDto>(entity);

            created.CategoryName = (await _db.Categories.FindAsync(entity.CategoryId))?.Name;

            return created;

        }
 
      
        public async Task<bool> DeleteAsync(int id)

        {

            var entity = await _db.Products.FindAsync(id);

            if (entity == null) return false;
 

            _db.Products.Remove(entity);

            await _db.SaveChangesAsync();

            return true;

        }
 
        public async Task<IEnumerable<ProductListDto>> GetFeaturedAsync(int count = 10)

        {

            var items = await _db.Products

                .AsNoTracking()

                .Where(p => p.Featured)

                .OrderByDescending(p => p.Rating)

                .Take(count)

                .ToListAsync();
 
            return _mapper.Map<List<ProductListDto>>(items);

        }
 
        public async Task<IEnumerable<ProductListDto>> GetByCategoryAsync(int categoryId, int limit = 50)

        {

            var items = await _db.Products

                .AsNoTracking()

                .Where(p => p.CategoryId == categoryId)

                .OrderByDescending(p => p.Featured)

                .Take(limit)

                .ToListAsync();
 
            return _mapper.Map<List<ProductListDto>>(items);

        }
 
        public async Task<IEnumerable<ProductListDto>> SearchAsync(string query, int limit = 20)

        {

            if (string.IsNullOrWhiteSpace(query)) return Array.Empty<ProductListDto>();
 
            var q = query.Trim();

            var items = await _db.Products

                .AsNoTracking()

                .Where(p => p.Name.Contains(q) || p.Brand.Contains(q) || p.Description.Contains(q))

                .OrderByDescending(p => p.Rating)

                .Take(limit)

                .ToListAsync();
 
            return _mapper.Map<List<ProductListDto>>(items);

        }

        public async Task<ProductDetailDto?> UpdateAsync(int id, ProductUpdateDto dto)

        {

            var entity = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null) return null;

            entity.Name = dto.Name;

            entity.Brand = dto.Brand;

            entity.CategoryId = dto.CategoryId;

            entity.Price = dto.Price;

            entity.Discount = dto.Discount;

            entity.Description = dto.Description;

            entity.Image = dto.Image;

            entity.InStock = dto.InStock;

            entity.Featured = dto.Featured;

            // AvailableVolumes enum mapping

            if (dto.AvailableVolumes != null)

            {

                entity.AvailableVolumes = dto.AvailableVolumes.Select(v => v switch

                {

                    30 => Volume.ML30,

                    50 => Volume.ML50,

                    100 => Volume.ML100,

                    _ => throw new ArgumentException($"Invalid volume: {v}")

                }).ToArray();

            }

            _db.Products.Update(entity);

            await _db.SaveChangesAsync();

            var updated = _mapper.Map<ProductDetailDto>(entity);

            updated.CategoryName = entity.Category?.Name;

            return updated;

        }


    }

}

 