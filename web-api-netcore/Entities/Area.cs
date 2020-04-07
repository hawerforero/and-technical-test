/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : Area                                                                  
 * Descripcion   : Entidad Area
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
    /// Entidad Area => Table Areas
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Identificación del area
        /// </summary>
        public int Id { get; set; }
        //Nombre del area
        public string Nombre { get; set; }
    }
}
