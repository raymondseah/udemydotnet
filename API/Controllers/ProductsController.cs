
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //inject the StoreContext into the controller
        //context use for http 

        // public readonly StoreContext _context;

        // public ProductsController(StoreContext context)
        // {
        //     _context = context;
        // }

        // with the IRepo in place, replacement the Controller with the IRepos
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // `/api/Products` to list all product
        // better to use async method, add asyc with Task and await to the var variable created and the ToList() => ToListAsync()
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // using ToList to get Products from the defined context above
            // var products = await _context.Products.ToListAsync();

            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // var products = await _context.Products.FindAsync(id);

            return await _repo.GetProductByIdAsync(id);
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            // using ToList to get Products from the defined context above
            // var products = await _context.Products.ToListAsync();

            return Ok(await _repo.GetProductBrandAsync());

        }
        


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            // using ToList to get Products from the defined context above
            // var products = await _context.Products.ToListAsync();
            return Ok(await _repo.GetProductTypesAsync());

        }
    }
}