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
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }
        //retornar una respuesta
        //[HttpGet("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listCategories = await _context.Categories.ToListAsync();
            if (listCategories == null || listCategories.Count == 0)
            {
                return NoContent();

            }
            return Ok(listCategories);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Categories categories)
        {
            if (categories == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(categories);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var categories = await _context.Categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] Categories categories){
            if(categories==null || categories.Id !=id){
                return BadRequest();
            }
            var entity = await _context.Categories.FindAsync(id);
            if(entity==null){
                return NotFound();
            }
            entity.Nombre = categories.Nombre;
            entity.FechaCreacion = categories.FechaCreacion;
            entity.FechaActualizacion = categories.FechaActualizacion;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}