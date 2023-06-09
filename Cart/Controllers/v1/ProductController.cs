using AutoMapper;
using Cart_API.Data.Dtos;
using Cart_API.Data;
using Cart_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cart_API.Controllers.v1
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private ProductContext _context;
        private IMapper _mapper;
        public ProductController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(SearchProductById), new { Id = product.Id }, product);
        }

        [HttpGet("ShowAllProducts")]
        public IEnumerable<Product> ShowAllProducts()
        {
            return _context.Products;
        }

        [HttpGet("SearchProductById/{id}")]
        public IActionResult SearchProductById(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product != null)
            {
                ReadProductDto productDto = _mapper.Map<ReadProductDto>(product);

                return Ok(productDto);
            }
            return NotFound("Product not found");
        }

        [HttpPost("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _mapper.Map(productDto, product);
            _context.SaveChanges();
            return Ok(productDto);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _context.Remove(product);
            _context.SaveChanges();
            return Ok("Product deleted");
        }
    }
}
