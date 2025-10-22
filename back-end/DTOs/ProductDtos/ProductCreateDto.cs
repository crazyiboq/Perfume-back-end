namespace back_end.DTOs.ProductDtos;



public class ProductCreateDto

{

    public string Name { get; set; }

    public string Brand { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public int[] AvailableVolumes { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public bool InStock { get; set; }

    public bool Featured { get; set; }

}

