using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Streeta.API.Data;
using Streeta.API.Models;

namespace Streeta.API.Controllers
{
    [ApiController]
    [Route("/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromServices] DataBaseContext context) => Ok(context.Categoria!.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria,
            [FromServices] DataBaseContext context)
            {
                context.Categoria!.Add(categoria);
                context.SaveChanges();
                return Created($"/{categoria.Id}", categoria);
            }

        [HttpGet("categorias/{id:int}")]
        public IActionResult GetById([FromRoute] int id,
            [FromServices] DataBaseContext context)
        {
            var categoria = context.Categoria!.FirstOrDefault(x => x.Id == id);
            if(categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPut("categorias/{id:int}")]
        public IActionResult Put([FromBody] Categoria categoria, int id,
            [FromServices] DataBaseContext context)
        {
            Console.WriteLine(id);
            var model = context.Categoria!.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }

            model.Nome = categoria.Nome;

            context.Categoria!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("categorias/{id:int}")]
        public IActionResult Delete(int id,
            [FromServices] DataBaseContext context)
        {
            var model = context.Categoria!.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }

            context.Categoria!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}