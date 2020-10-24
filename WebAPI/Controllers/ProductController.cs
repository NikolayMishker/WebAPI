using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repo;

        public ProductsController(IProductRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await repo.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await repo.GetProductByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            return Ok(await repo.GetProductTypesAsync());
        }

    }
}
