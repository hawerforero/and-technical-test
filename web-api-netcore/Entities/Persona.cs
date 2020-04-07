/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : Persona                                                                  
 * Descripcion   : Entidad Persona
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

namespace WebApiAND.Entities
{
    /// <summary>
    /// Entidad Persona => Table Personas
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Identificación de la persona
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Nombre { get; set; }
    }
}
