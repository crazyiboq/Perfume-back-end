using System.Text.Json;

namespace back_end.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public Volume[] AvailableVolumes { get; set; } = Array.Empty<Volume>();
        public decimal Rating { get; set; }
        public int Reviews { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public bool Featured { get; set; }
    }
}