using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock
{
    public class ExisteTipoCU : IExisteTipoCU
    {
        private IRepositorioMovimientoStock _repoMovimientoStock;
        public ExisteTipoCU(IRepositorioMovimientoStock repoMovimientoStock)
        {
            _repoMovimientoStock = repoMovimientoStock;
        }
        public bool ExisteTipo(string tipo)
        {
            return _repoMovimientoStock.ExisteTipo(tipo);
        }
    }
}
