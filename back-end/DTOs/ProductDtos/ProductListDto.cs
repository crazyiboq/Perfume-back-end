namespace back_end.DTOs.ProductDtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public decimal Price { get; set; }
        public decimal? Discount { get; set; }

        public string Image { get; set; }
        public bool InStock { get; set; }

        public decimal Rating { get; set; }
        public int Reviews { get; set; }

        public bool Featured { get; set; }
    }
}