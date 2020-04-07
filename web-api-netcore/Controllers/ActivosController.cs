
/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : ActivosController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a Activos
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
    /// Controlador CRUD Activos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        /// <summary>
        /// Context Entity framework
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public ActivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  GET: Consulta listado de activos
        /// </summary>
        /// <returns>Listado de Activos</returns>
        [HttpGet]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<IEnumerable<Activo>>> GetActivos()
        {
            return await _context.Activos.Include(x => x.TipoActivo).ToListAsync();
        }

        /// <summary>
        /// GET: Consulta un activo especifico
        /// </summary>
        /// <param name="id">Identificación del activo</param>
        /// <returns>Información del activo</returns>
        [HttpGet("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Activo>> GetActivo(long id)
        {
            //var activo = await _context.Activos.FindAsync(id);
            var activo = await _context.Activos.Include(x => x.TipoActivo).FirstOrDefaultAsync(x => x.Id == id);

            if (activo == null)
            {
                return NotFound();
            }

            return activo;
        }

        /// <summary>
        /// POST: Inserta un activo
        /// </summary>
        /// <param name="activo">Información del activo</param>
        /// <returns>Activo creado</returns>
        [HttpPost]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Activo>> PostActivo(Activo activo)
        {
            activo.Estado = "Disponible";
            _context.Activos.Add(activo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivo", new { id = activo.Id }, activo);
        }

        /// <summary>
        /// PUT: Actualiza un activo
        /// </summary>
        /// <param name="id">Identificación del activo</param>
        /// <param name="activo">Instancia del activo</param>
        /// <returns>Activo actualizado</returns>
        [HttpPut("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<IActionResult> PutActivo(long id, Activo activo)
        {
            if (id != activo.Id)
            {
                return BadRequest();
            }

            _context.Entry(activo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoExists(id))
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
        /// DELETE: Elimina un activo
        /// </summary>
        /// <param name="id">Identificación dl activo</param>
        /// <returns>Activo eliminado</returns>
        [HttpDelete("{id}")]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<Activo>> DeleteActivo(long id)
        {
            var activo = await _context.Activos.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }

            _context.Activos.Remove(activo);
            await _context.SaveChangesAsync();

            return activo;
        }

        /// <summary>
        /// Validación existencia activo
        /// </summary>
        /// <param name="id">Identificación del activo</param>
        /// <returns>False - True</returns>
        private bool ActivoExists(long id)
        {
            return _context.Activos.Any(e => e.Id == id);
        }
    }
}
