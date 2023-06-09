using System.ComponentModel.DataAnnotations;

namespace Cart_API.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string ProductName { get; set; }

        public double Price { get; set; }

        public bool Saled { get; set; }
    }
}
