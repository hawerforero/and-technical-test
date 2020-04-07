/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : MovimientosController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a Movimientos
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
    /// Controlador CRUD Movimientos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        /// <summary>
        /// Context Entity Framework
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public MovimientosController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        /// <summary>
        /// GET: Consulta el listado de movimientos
        /// </summary>
        /// <returns>Listado de movimientos</returns>
        [HttpGet]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
        {
            return await _context.Movimientos.Include(x => x.TipoMovimiento).Include(x => x.Activo).Include(x => x.Persona).Include(x => x.Area).ToListAsync();
        }

        /// <summary>
        /// GET: Consulta un movimiento especifico
        /// </summary>
        /// <param name="id">Identificación del movimiento</param>
        /// <returns>Información del movimiento</returns>
        [HttpGet("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return movimiento;
        }

        /// <summary>
        /// PUT: Actualiza un movimiento
        /// </summary>
        /// <param name="id">Identificación del movimiento</param>
        /// <param name="movimiento">Información del movimiento</param>
        /// <returns>Movimiento actualizado</returns>
        [HttpPut("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<IActionResult> PutMovimiento(int id, Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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
        /// POST: Inserta un movimiento
        /// </summary>
        /// <param name="movimiento">Información del movimiento</param>
        /// <returns>Movimiento creado</returns>
        [HttpPost]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {

            movimiento.Fecha = DateTime.Today;
            var activo = _context.Activos.FirstOrDefault(x => x.Id == movimiento.ActivoId);
            if (movimiento.TipoMovimientoId == 1)
            {
                if (activo.Estado == "Asignado")
                {
                    return NotFound();
                }
                activo.Estado = "Asignado";
            }
            else
            {
                activo.Estado = "Disponible";
            }
            _context.Entry(activo).State = EntityState.Modified;

            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimiento", new { id = movimiento.Id }, movimiento);

        }

        /// <summary>
        /// DELETE: Eliminar un movimiento
        /// </summary>
        /// <param name="id">Identificación del movimiento</param>
        /// <returns>Movimiento eliminado</returns>
        [HttpDelete("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Movimiento>> DeleteMovimiento(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();

            return movimiento;
        }

        /// <summary>
        /// Validación existencia del movimiento
        /// </summary>
        /// <param name="id">Identificación del movimiento</param>
        /// <returns>False - True</returns>
        private bool MovimientoExists(int id)
        {
            return _context.Movimientos.Any(e => e.Id == id);
        }
    }
}
