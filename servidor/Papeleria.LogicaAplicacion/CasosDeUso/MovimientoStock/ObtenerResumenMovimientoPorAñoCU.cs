using Papeleria.LogicaAplicacion.DTOs;
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
        private IGetAllMovimientosCU _getMovimientosCU;
        public ObtenerResumenMovimientoPorAñoCU(IGetAllMovimientosCU getAllMovimientosCU)
        {
            this._getMovimientosCU = getAllMovimientosCU;
        }

        public IEnumerable<ResumenMovimientosDTO> ObtenerResumenMovimiento()
        {
            IEnumerable<MovimientoStockDTO> movimientos =
                this._getMovimientosCU.GetAllMovimientosCU();
            var result = movimientos.GroupBy(movimientos => movimientos.fechaYHora.Year)
                    .Select(movimientosAgrupados => new ResumenMovimientosDTO
                    {
                        Año = movimientosAgrupados.Key,
                        //NombreTipoMovimientos = movimientosAgrupados.,
                        TotalCantidadesMovidas = movimientosAgrupados.Sum(mv =>
                                    mv.cantUnidadesMovidas
                                ),
                        movimientos = movimientosAgrupados
                                   .GroupBy(movimientos => movimientos.tipoMovimiento)
                                   .Select(movimientos => new MovimientosTipoAño
                                   {
                                       tipoMovimiento = movimientos.Key,
                                       cantidadMovimientos = movimientos.Sum(movimiento => movimiento.cantUnidadesMovidas)
                                   }).ToList()
                    }
                    );
            return result;

        }

    }
}
