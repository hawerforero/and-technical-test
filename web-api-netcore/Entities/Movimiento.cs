/************************************************************************************************************************
 * Propiedad intelectual de la AND
 ************************************************************************************************************************
 * Unidad        : Movimiento                                                                  
 * Descripcion   : Entidad Movimiento
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
    /// Entidad Movimiento => Table Movimientos
    /// </summary>
    public class Movimiento
    {
        /// <summary>
        /// Identificación del movimiento
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        /// <summary>
        /// Fecha del movimiento
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Identificacdor del tipo de movimiento
        /// </summary>
        public int TipoMovimientoId { get; set; }
        /// <summary>
        /// Instancia de Tipo de movimiento
        /// </summary>
        public TipoMovimiento TipoMovimiento { get; set; }
        /// <summary>
        /// Identificacdor del activo
        /// </summary>
        public long ActivoId { get; set; }
        /// <summary>
        /// Instancia del Activo
        /// </summary>
        public Activo Activo { get; set; }
        /// <summary>
        /// Identificacdor de la persona
        /// </summary>
        public int? PersonaId { get; set; }
        /// <summary>
        /// Instancia de la persona
        /// </summary>
        public Persona Persona { get; set; }
        /// <summary>
        /// Identificacdor del area
        /// </summary>
        public int? AreaId { get; set; }
        /// <summary>
        /// Instancia del area
        /// </summary>
        public Area Area { get; set; }
        /// <summary>
        /// Observación del movimiento
        /// </summary>
        public string Observacion { get; set; }

    }
}
