namespace back_end.Helpers

{

    public class ProductQueryParams

    {

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string? Search { get; set; }

        public int? CategoryId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        // sort: price_asc, price_desc, newest, featured, rating_desc

        public string? Sort { get; set; }

        public bool? InStock { get; set; }

    }

}

