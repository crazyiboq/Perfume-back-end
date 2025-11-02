using back_end.Models.Entity;

namespace back_end.Models;

public class ProductImage : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string Url { get; set; } = default!;

    public string? PublicId { get; set; }
    public int Sort { get; set; }



}