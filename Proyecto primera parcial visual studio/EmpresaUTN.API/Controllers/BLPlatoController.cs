using System;
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
    public class DALPaisController : ControllerBase
    {
        private readonly DataContext _context;

        public DALPaisController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DALRestaurante

        //ruta de precio total
        [Route("/BL/AreaTotal")]
        [HttpGet]
//   
        public async Task<ActionResult<double>> PlatoTotal()

        {
            if (_context.Restaurantes == null)
            {
                return NotFound();
            }
            //return await _context.Restaurantes.ToListAsync();

            //sacar la suma de los precios de los platos de cada restaurante 
            return _context.Platos.Sum(p => p.Precio);


            
        }


    }
}
