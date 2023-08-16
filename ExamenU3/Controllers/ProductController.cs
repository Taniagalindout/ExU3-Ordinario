using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ExamenU3.Models;

namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listProduct = await _context.Products.ToListAsync();
            if (listProduct == null || listProduct.Count == 0)
            {

                return NoContent();
            }

            return Ok(listProduct);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Product product)
        {
            if (product == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(product);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Product product){
            if (product == null)
            {
                return BadRequest(); // Error 400
            }
            var entity = await _context.Products.FindAsync(product.Id);
            if (entity == null) {
             return NotFound();   // Error 404
            }
            entity.Nombre = product.Nombre;
            entity.Descripcion = product.Descripcion;
            entity.Precio = product.Precio;
            entity.Cantidad = product.Cantidad;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}