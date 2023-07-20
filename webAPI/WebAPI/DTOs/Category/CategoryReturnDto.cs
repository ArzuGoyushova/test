namespace WebAPI.DTOs.Category
{
    public class CategoryReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ProductsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
