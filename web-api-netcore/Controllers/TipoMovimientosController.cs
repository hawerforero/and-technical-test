/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : TipoMovimientosController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a TipoMovimientos
 * Autor         : Hawer Forero Rey
 * Fecha         : 24/08/2019                                                                                                                                                                                        
 * Fecha         Autor          Modificación                                                                 
 * ===========   ============   =========================================================================================  
 * 
 ***********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAND.Contexts;
using WebApiAND.Entities;

namespace WebApiAND.Controllers
{
    /// <summary>
    /// Controlador CRUD TipoMovimientos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientosController : ControllerBase
    {
        /// <summary>
        /// Context Entity Framework
        /// </summary>
        private readonly ApplicationDbContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public TipoMovimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Consulta el listado de tipos de movimiento
        /// </summary>
        /// <returns>Listado de tipos de movimientos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimiento>>> GetTipoMovimientos()
        {
            return await _context.TipoMovimientos.ToListAsync();
        }

        /// <summary>
        /// GET: Consulta un tipo de movimiento especifico
        /// </summary>
        /// <param name="id">Identificación del tipo de movimiento</param>
        /// <returns>Información del tipo de movimiento</returns>
        [HttpGet("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<TipoMovimiento>> GetTipoMovimiento(int id)
        {
            var tipoMovimiento = await _context.TipoMovimientos.FindAsync(id);

            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            return tipoMovimiento;
        }

        /// <summary>
        /// PUT: Actualiza un tipo de movimiento 
        /// </summary>
        /// <param name="id">Identificación del tipo de movimiento</param>
        /// <param name="tipoMovimiento">Información del tipo movimiento</param>
        /// <returns>Tipo de Movimiento actualizado</returns>
        [HttpPut("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<IActionResult> PutTipoMovimiento(int id, TipoMovimiento tipoMovimiento)
        {
            if (id != tipoMovimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoMovimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMovimientoExists(id))
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

        /// <summary>
        /// POST: Inserta un tipo de movimiento
        /// </summary>
        /// <param name="tipoMovimiento">Información del tipo de movimiento</param>
        /// <returns>Tipo de Movimiento creado</returns>
        [HttpPost]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<TipoMovimiento>> PostTipoMovimiento(TipoMovimiento tipoMovimiento)
        {
            _context.TipoMovimientos.Add(tipoMovimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMovimiento", new { id = tipoMovimiento.Id }, tipoMovimiento);
        }

        /// <summary>
        /// DELETE: Elimina un tipo de movimiento
        /// </summary>
        /// <param name="id">Identificación del tipo de movimiento</param>
        /// <returns>Tipo de Movimiento eliminado</returns>
        [HttpDelete("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<TipoMovimiento>> DeleteTipoMovimiento(int id)
        {
            var tipoMovimiento = await _context.TipoMovimientos.FindAsync(id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            _context.TipoMovimientos.Remove(tipoMovimiento);
            await _context.SaveChangesAsync();

            return tipoMovimiento;
        }

        /// <summary>
        /// Validación existencia del tipo de movimiento
        /// </summary>
        /// <param name="id">Identificación del tipo de movimiento</param>
        /// <returns>False - True</returns>
        private bool TipoMovimientoExists(int id)
        {
            return _context.TipoMovimientos.Any(e => e.Id == id);
        }
    }
}
