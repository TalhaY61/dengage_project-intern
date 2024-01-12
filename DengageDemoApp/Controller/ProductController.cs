using DengageDemoApp.Application.Service;
using DengageDemoApp.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DengageDemoApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var getAllProducts = _productService.GetAllProducts();
            return Ok(getAllProducts);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductByID([FromRoute]int id)
        {
            var product = _productService.GetProductByID(id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var newproduct = _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProductByID), new { id = newproduct.ID }, newproduct);

        }

        //TODO: Update and Delete for Product
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedProduct = _productService.UpdateProduct(product);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductByID(int id)
        {
            var deletedProduct = _productService.DeleteProductByID(id);

            return Ok(deletedProduct);
        }
    }
}
