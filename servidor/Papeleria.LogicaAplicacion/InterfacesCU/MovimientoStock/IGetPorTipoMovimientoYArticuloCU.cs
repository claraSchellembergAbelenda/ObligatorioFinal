using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock
{
    public interface IGetPorTipoMovimientoYArticuloCU
    {
        public IEnumerable<MovimientoStockDTO> GetPorTipoMovimientoYArticulo(int idArticulo, string tipo);
    }
}
