using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cart_API.Data.Dtos
{
    public class ReadProductDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public bool Saled { get; set; }
    }
}
