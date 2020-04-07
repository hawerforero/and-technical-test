/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : TipoMovimiento                                                                  
 * Descripcion   : Entidad TipoMovimiento
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
    /// Entidad TipoMovimiento => Table TipoMovimientos
    /// </summary>
    public class TipoMovimiento
    {
        /// <summary>
        /// Identificación del tipo de movimiento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del tipo de movimiento
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Sigla del tipo de movimiento
        /// </summary>
        public string Sigla { get; set; }
    }
}
