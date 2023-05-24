﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpresaUTN.Modelos;

namespace EmpresaUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante()
        {
          if (_context.Restaurantes == null)
          {
              return NotFound();
          }
          //RETORNAR LOS RESTAURANTES CON SUS RESPECTIVOS PLATILLOS
            //return await _context.Restaurantes.Include(r => r.Platos).ToListAsync();


            //RETORNAR LOS RESTAURANTES CON SUS RESPECTIVOS PLATILLOS y sus respectivos ingredientes
             return await _context.Restaurantes.Include(r => r.Platos).ThenInclude(p => p.Ingredientes).ToListAsync();




            // return await _context.Restaurantes.ToListAsync();




        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
          if (_context.Restaurantes == null)
          {
              return NotFound();
          }

          //mostrar restaurante con sus platos y sus ingredientes
            var restaurante = await _context.Restaurantes.Include(r => r.Platos).ThenInclude(p => p.Ingredientes).FirstOrDefaultAsync(r => r.CodigoRestaurante == id);

            //var restaurante = await _context.Restaurantes.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        // PUT: api/Restaurantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(int id, Restaurante restaurante)
        {
            if (id != restaurante.CodigoRestaurante)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
          if (_context.Restaurantes == null)
          {
              return Problem("Entity set 'DataContext.Restaurante'  is null.");
          }
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurante", new { id = restaurante.CodigoRestaurante }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            if (_context.Restaurantes == null)
            {
                return NotFound();
            }
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestauranteExists(int id)
        {
            return (_context.Restaurantes?.Any(e => e.CodigoRestaurante == id)).GetValueOrDefault();
        }
    }
}
