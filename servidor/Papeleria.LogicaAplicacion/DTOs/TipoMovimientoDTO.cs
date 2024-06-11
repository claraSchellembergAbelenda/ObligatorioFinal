using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class TipoMovimientoDTO
    {
        public int id { get; set; }
        public string nombreMovimiento { get; set; }
        public bool esPositivo { get; set; }

        public TipoMovimientoDTO() { }
        public TipoMovimientoDTO(int id, string nombreMovimiento, bool esPositivo)
        {
            this.id = id;
            this.nombreMovimiento = nombreMovimiento;
            this.esPositivo = esPositivo;
        }

        public TipoMovimientoDTO(TipoMovimiento tp)
        {
            if (tp != null)
            {
                id = tp.id;
                nombreMovimiento=tp.nombreMovimiento;
                esPositivo = tp.esPositivo;
            }
        }
    }
}
