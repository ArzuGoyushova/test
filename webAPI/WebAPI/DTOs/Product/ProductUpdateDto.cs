namespace WebAPI.DTOs.Product
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
