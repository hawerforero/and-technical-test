/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : Activo                                                                  
 * Descripcion   : Entidad Activo
 * Autor         : Hawer Forero Rey
 * Fecha         : 24/08/2019                                                                                                                                                                                        
 * Fecha         Autor          Modificación                                                                 
 * ===========   ============   =========================================================================================  
 * 
 ***********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAND.Entities
{
    /// <summary>
    /// Entidad Activo => Table Activos
    /// </summary>
    public class Activo
    {
        /// <summary>
        /// Identificador del activo
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set;}
        /// <summary>
        /// Nombre del activo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del activo
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Identificador del tipo de activo
        /// </summary>
        public long TipoActivoId { get; set; }
        /// <summary>
        /// Instancia del tipo de activo
        /// </summary>
        public TipoActivo TipoActivo { get; set; }
        /// <summary>
        /// Serial del activo
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// Valor de compra
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Fecha de compra
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Estado actual (Disponible , Asignado)
        /// </summary>
        public string Estado { get; set; }

    }
}
