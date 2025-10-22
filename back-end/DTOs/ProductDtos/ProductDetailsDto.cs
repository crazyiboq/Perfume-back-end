namespace PerfumeShop.DTOs.Product

{

    public class ProductDetailDto

    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public int[] AvailableVolumes { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool InStock { get; set; }

        public decimal Rating { get; set; }

        public int Reviews { get; set; }

        public bool Featured { get; set; }

        public string CategoryName { get; set; }

    }

}

