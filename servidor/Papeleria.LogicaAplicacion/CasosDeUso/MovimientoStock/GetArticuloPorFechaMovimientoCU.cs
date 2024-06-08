using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock
{
    public class GetArticuloPorFechaMovimientoCU : IGetArticuloPorFechaMovimiento
    {
        private IRepositorioMovimientoStock _repoMovimientoStock;
        public GetArticuloPorFechaMovimientoCU(IRepositorioMovimientoStock repoMovimientoStock)
        {
            _repoMovimientoStock = repoMovimientoStock;
        }

        public IEnumerable<ArticuloDTO> GetArticuloPorFechas(DateTime f1, DateTime f2)
        {
           var articulos= _repoMovimientoStock.GetArticuloPorFechaMovimiento(f1, f2);
           return articulos.Select(a => ArticuloDtoMapper.ToDto(a));
        }
    }
}
