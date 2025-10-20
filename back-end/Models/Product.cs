using back_end.Modelsl;

namespace back_end.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public string Brand { get; set;}
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set;}

        public Volume[] AvaibleVolumesnu { get; set; }
        
        public decimal Rating { get; set; }

        public int reviews { get; set; }

        public string description { get; set; }

        public string Image { get; set;}

        public bool InStock { get; set;}

        public bool Featured { get; set;}
    }
}
