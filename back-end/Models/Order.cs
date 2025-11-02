using back_end.Models.Entity;
using PerfumeApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace back_end.Models;

public class Order:BaseEntity
{
    public int UserId { get; set; }

    public string CustomerName { get; set; } = default!;
    public string CustomerEmail { get; set; } = default!;
    public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

    
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }


    public OrderShipping Shipping { get; set; } = new();
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

}
