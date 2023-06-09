namespace Cart_API.Data.Dtos
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool Saled { get; set; }
    }
}
