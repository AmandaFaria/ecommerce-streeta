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
    [Route("/cupons")]
    public class CupomController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
           [FromServices] DataBaseContext context) => Ok(context.Cupom!.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Cupom cupom,
            [FromServices] DataBaseContext context)
        {
            context.Cupom!.Add(cupom);
            context.SaveChanges();
            return Created($"/{cupom.Id}", cupom);
        }

        [HttpGet("cupons/{id:int}")]
        public IActionResult GetById([FromRoute] int id,
            [FromServices] DataBaseContext context)
        {
            var cupom = context.Cupom!.FirstOrDefault(x => x.Id == id);
            if (cupom == null)
            {
                return NotFound();
            }

            return Ok(cupom);
        }

        [HttpPut("cupons/{id:int}")]
        public IActionResult Put([FromBody] Cupom cupom, int id,
            [FromServices] DataBaseContext context)
        {
            Console.WriteLine(id);
            var model = context.Cupom!.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            model.Porcentagem = cupom.Porcentagem;

            context.Cupom!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("cupons/{id:int}")]
        public IActionResult Delete(int id,
            [FromServices] DataBaseContext context)
        {
            var model = context.Cupom!.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            context.Cupom!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}