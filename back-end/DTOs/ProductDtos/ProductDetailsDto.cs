using back_end.Models;
using back_end.DTOs.ProductNotesDTOs;
namespace PerfumeShop.DTOs.Product

{

    public class ProductDetailDto

    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Gender gender { get; set; }
            
        public int Reviews { get; set; }
        public decimal Rating { get; set; }
        public bool Featured { get; set; }

        public ProductsNotesDetailsDto? Notes { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVolume> Volumes { get; set; } = new List<ProductVolume>();
    }

}

