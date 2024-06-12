using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock
{
    public class ObtenerResumenMovimientoPorAñoCU : IGetResumeByYearAndTypeUC
    {
        private IRepositorioMovimientoStock _repoMovimientoStock;
        public ObtenerResumenMovimientoPorAñoCU(IRepositorioMovimientoStock repositorioMovimiento)
        {
            this._repoMovimientoStock = repositorioMovimiento;
        }

        public IEnumerable<LogicaNegocios.Entidades.MovimientoStock> ObtenerResumenMovimiento()
        {
            IEnumerable<LogicaNegocios.Entidades.MovimientoStock> movimientos = _repoMovimientoStock.FindAll();
            movimientos.GroupBy(m => new { Año = m.fechaYHora.Year, TipoMovimiento = m.tipoMovimiento.nombreMovimiento })
                .Select(grupoMovimientos => new
                {
                    Año = grupoMovimientos.Key,
                    Tipo = grupoMovimientos.Key.TipoMovimiento,
                    TotalUnidadesMovidas = grupoMovimientos.Sum(mv => mv.cantUnidadesMovidas)
                })
                .OrderBy(gm => gm.Año)
                .ThenBy(gm => gm.Tipo)
                .ToList();
            return movimientos;

        }

    }
}
