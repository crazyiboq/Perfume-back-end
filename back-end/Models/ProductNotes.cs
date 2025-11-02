using back_end.Models.Entity;

namespace back_end.Models
{
    public class ProductNotes: BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string? Top { get; set; }
        public string? Heart { get; set; }
        public string? Base { get; set; }

    }
}
