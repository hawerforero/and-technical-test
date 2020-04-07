/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : PersonasController                                                                  
 * Descripcion   : Controlador usado para realizar el CRUD a Personas
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
    /// Controlador CRUD Personas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        /// <summary>
        /// Context Entity Framework
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Inyección context de la bd</param>
        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Consulta el listado de personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        [HttpGet]
        [EnableCors("PermitirApiRequest")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        /// <summary>
        /// GET: Consulta una persona especifica
        /// </summary>
        /// <param name="id">Identificación de la persona</param>
        /// <returns>Información de la persona</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        /// <summary>
        /// PUT: Actualiza una persona
        /// </summary>
        /// <param name="id">Identificación de la persona</param>
        /// <param name="persona">Información de la persona</param>
        /// <returns>Persona actualizada</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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
        /// POST: Inserta una persona
        /// </summary>
        /// <param name="area">Información de la persona</param>
        /// <returns>Persona creada</returns>
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        /// <summary>
        /// DELETE: Elimina una persona
        /// </summary>
        /// <param name="id">Identificación de la persona</param>
        /// <returns>Persona eliminada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona>> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        /// <summary>
        /// Validación existencia de la persona
        /// </summary>
        /// <param name="id">Identificación de la persona</param>
        /// <returns>False - True</returns>
        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
