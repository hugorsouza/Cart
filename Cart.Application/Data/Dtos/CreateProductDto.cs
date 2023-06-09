using System.ComponentModel.DataAnnotations;

namespace Cart_API.Data.Dtos
{
    public class CreateProductDto
    {
        [Key]
        public int IdProduct { get; set; }

        [Required, MaxLength(128)]
        public string ProductName { get; set; }

        public int Stock { get; set; }

        public double Price { get; set; }
        public string Status { get; set; }
    }
}
