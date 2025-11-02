using back_end.Models.Entity;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace back_end.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Gender gender { get; set; }

        public int Reviews { get; set; }

        public decimal Rating { get; set; }
        public bool Featured { get; set; }

        public ProductNotes? Notes { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVolume> Volumes { get; set; } = new List<ProductVolume>();

    }
}