namespace WebAPI.DTOs.Product
{
    public class ProductListDto
    {
        public int TotalCount { get; set; }
        public List<ProductListItemDto> Items { get; set; }

    }
}
