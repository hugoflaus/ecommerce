using System.Linq;
using api.Models;
using api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDBContext _ecommerceDBContext;
        public ProductsController(EcommerceDBContext eccomerceDBContext)
        {
            _ecommerceDBContext = eccomerceDBContext;
        }

        // api/products
        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDBContext.Produtcs.ToList();
            
            return Ok(products);
        }

        // api/products/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDBContext.Produtcs.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }
           
            return Ok(product);
            
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ProductInputModel productInputModel)
        {
            var product = new Product(productInputModel.Description, productInputModel.Price);

            _ecommerceDBContext.Produtcs.Add(product);
            _ecommerceDBContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

        }

    }
}