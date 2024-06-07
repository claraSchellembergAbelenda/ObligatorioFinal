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

        public TipoMovimientoDTO() { }
        public TipoMovimientoDTO(int id, string nombreMovimiento)
        {
            this.id = id;
            this.nombreMovimiento = nombreMovimiento;
        }

        public TipoMovimientoDTO(TipoMovimiento tp)
        {
        }
    }
}
