namespace Cart_API.Data.Dtos
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
