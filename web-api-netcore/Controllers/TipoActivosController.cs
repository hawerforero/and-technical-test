/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : TipoActivosController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a TipoActivos
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
    /// Controlador CRUD TipoActivos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActivosController : ControllerBase
    {
        /// <summary>
        /// Context Entity Framework
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public TipoActivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Consulta el listado de tipo de activos
        /// </summary>
        /// <returns>Listado de tipos de activos</returns>
        [HttpGet]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<IEnumerable<TipoActivo>>> GetTipoActivos()
        {
            return await _context.TipoActivos.ToListAsync();
        }

        /// <summary>
        /// GET: Consulta un tipo de activo especifico
        /// </summary>
        /// <param name="id">Identificación del tipo del activo</param>
        /// <returns>Información del tipo de activo</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoActivo>> GetTipoActivo(long id)
        {
            var tipoActivo = await _context.TipoActivos.FindAsync(id);

            if (tipoActivo == null)
            {
                return NotFound();
            }

            return tipoActivo;
        }

        /// <summary>
        /// PUT: Actualiza un tipo de activo
        /// </summary>
        /// <param name="id">Identificación del tipo de activo</param>
        /// <param name="tipoActivo">Información del tipo de activo</param>
        /// <returns>Tipo activo actualizado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActivo(long id, TipoActivo tipoActivo)
        {
            if (id != tipoActivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoActivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActivoExists(id))
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
        /// POST: Inserta un tipo de activo
        /// </summary>
        /// <param name="tipoActivo">Información del tipo de Activo</param>
        /// <returns>Tipo de activo creado</returns>
        [HttpPost]
        public async Task<ActionResult<TipoActivo>> PostTipoActivo(TipoActivo tipoActivo)
        {
            _context.TipoActivos.Add(tipoActivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoActivo", new { id = tipoActivo.Id }, tipoActivo);
        }

        /// <summary>
        /// DELETE: Elimina un tipo de activo
        /// </summary>
        /// <param name="id">Identificación del tipo de activo</param>
        /// <returns>Tipo activo eliminado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoActivo>> DeleteTipoActivo(long id)
        {
            var tipoActivo = await _context.TipoActivos.FindAsync(id);
            if (tipoActivo == null)
            {
                return NotFound();
            }

            _context.TipoActivos.Remove(tipoActivo);
            await _context.SaveChangesAsync();

            return tipoActivo;
        }

        /// <summary>
        /// Validación existencia del tipo de activo
        /// </summary>
        /// <param name="id">Identificación del tipo de activo</param>
        /// <returns>False - True</returns>
        private bool TipoActivoExists(long id)
        {
            return _context.TipoActivos.Any(e => e.Id == id);
        }
    }
}
