using back_end.Models.Entity;

namespace back_end.Models;

public class OrderShipping:BaseEntity
{
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public string Country { get; set; } = default!;
}
