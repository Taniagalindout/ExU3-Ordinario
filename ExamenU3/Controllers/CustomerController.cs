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
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        //retornar una respuesta
        //[HttpGet("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listCustomers = await _context.Customer.ToListAsync();
            if (listCustomers == null || listCustomers.Count == 0)
            {
                return NoContent();

            }
            return Ok(listCustomers);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] Customer customer){
            if(customer==null || customer.Id !=id){
                return BadRequest();
            }
            var entity = await _context.Customers.FindAsync(id);
            if(entity==null){
                return NotFound();
            }
            entity.Nombre = customer.Nombre;
            entity.Nombre = customer.Apellidos;
            entity.Nombre = customer.RFC;
            entity.Nombre = customer.CorreoElectronico;
            entity.Nombre = customer.Telefono;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}