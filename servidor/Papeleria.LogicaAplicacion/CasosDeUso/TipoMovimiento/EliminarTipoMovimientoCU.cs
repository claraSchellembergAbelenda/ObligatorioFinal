using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class EliminarTipoMovimientoCU : IEliminarTipoMovimientoCU
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public EliminarTipoMovimientoCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void EliminarTipoMovimiento(int idAEliminar)
        {
            _repositorioTipoMovimiento.Remove(idAEliminar);
        }
    }
}
