namespace ProductsMiddleware.Models
{
    public class ProductResponse
    {
        public List<ProductItem> products { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }
}
