using System.ComponentModel.DataAnnotations;

namespace back_end.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
