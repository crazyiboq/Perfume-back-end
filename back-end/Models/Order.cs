using PerfumeApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace back_end.Models;

public class Order
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;


    public int UserId { get; set; }
    public User User { get; set; }


}
