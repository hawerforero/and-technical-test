/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : AreasController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a Areas
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
    /// Controlador CRUD Areas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        /// <summary>
        /// Context Entity Framework
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public AreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Consulta las áreas
        /// </summary>
        /// <returns>Listado de areas</returns>
        [HttpGet]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        /// <summary>
        /// GET: Consulta un área especifica
        /// </summary>
        /// <param name="id">Identificación del area</param>
        /// <returns>Información del area</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        /// <summary>
        /// PUT: Actualiza un área
        /// </summary>
        /// <param name="id">Identificación del area</param>
        /// <param name="area">Información del area</param>
        /// <returns>Area actualizada</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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
        /// POST: Inserta un área
        /// </summary>
        /// <param name="area">Información del area</param>
        /// <returns>Area creada</returns>
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        /// <summary>
        /// DELETE: Elimina un área
        /// </summary>
        /// <param name="id">Identificación del area</param>
        /// <returns>Area eliminada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Area>> DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return area;
        }

        /// <summary>
        /// Validación existencia del area
        /// </summary>
        /// <param name="id">Identificación del area</param>
        /// <returns>False - True</returns>
        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
