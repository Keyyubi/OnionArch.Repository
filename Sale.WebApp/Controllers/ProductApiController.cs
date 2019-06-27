using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sale.Service;
using Sale.Data.Model;

namespace CrazySale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        /* GET: api/productapi/5a34-212e
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            //Guid gui = Guid.Parse(id);
            //var product = await _productService.GetProduct(gui);

            //if (product == null)
            //{
            //    return NotFound();
            //}

            return new Product();
        }

        // GET: api/productapi
        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productService.GetOnSaleProducts();

            if (products == null)
                return NotFound();

            return products;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<bool>> PostProducts(Product prd)
        {
            var result = await _productService.AddProductAsync(prd);

            if(!result)
                return BadRequest();
            
            return Ok("Ürün oluşturma başarılı.");
        }

        */

    }
}