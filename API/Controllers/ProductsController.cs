
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //inject the StoreContext into the controller
        //context use for http 
        public readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // `/api/Products` to list all product
        // better to use async method, add asyc with Task and await to the var variable created and the ToList() => ToListAsync()
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // using ToList to get Products from the defined context above
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

    }
}