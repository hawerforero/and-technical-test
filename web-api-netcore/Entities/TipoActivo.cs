/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : TipoActivo                                                                  
 * Descripcion   : Entidad TipoActivo
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
    /// Entidad TipoActivo => Table TipoActivos
    /// </summary>
    public class TipoActivo
    {
        /// <summary>
        /// Identificador del tipo de activo
        /// </summary>
        public long Id { get; set;}
        /// <summary>
        /// Nombre del tipo de Activo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Sigla del tipo de activo
        /// </summary>
        public string Sigla { get; set; }
    }
}
