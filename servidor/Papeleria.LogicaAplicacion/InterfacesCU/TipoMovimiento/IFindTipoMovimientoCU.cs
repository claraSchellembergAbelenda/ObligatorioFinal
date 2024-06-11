using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento
{
    public interface IFindTipoMovimientoCU
    {
        public TipoMovimientoDTO FindTipoMovimiento(int id);
    }
}
