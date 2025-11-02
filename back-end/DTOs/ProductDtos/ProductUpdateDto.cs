using back_end.Models;

namespace back_end.DTOs.ProductDtos;



public class ProductUpdateDto

{

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public Gender gender { get; set; }
    public bool Featured { get; set; }

    public ProductNotes? Notes { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<ProductVolume> Volumes { get; set; } = new List<ProductVolume>();

}

