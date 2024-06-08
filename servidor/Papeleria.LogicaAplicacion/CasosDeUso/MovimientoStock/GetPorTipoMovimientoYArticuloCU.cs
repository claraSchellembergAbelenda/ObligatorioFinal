using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock
{
    public class GetPorTipoMovimientoYArticuloCU : IGetPorTipoMovimientoYArticuloCU
    {
        private IRepositorioMovimientoStock _repoMovimientoStock;
        public GetPorTipoMovimientoYArticuloCU(IRepositorioMovimientoStock repoMovimientoStock)
        {
            _repoMovimientoStock = repoMovimientoStock;
        }
        public IEnumerable<MovimientoStockDTO> GetPorTipoMovimientoYArticulo(int idArticulo, string tipo)
        {
            var movimientos =_repoMovimientoStock.GetPorTipoYArticulo(idArticulo, tipo);
            return movimientos.Select(m => MovimientoStockDtoMapper.ToDto(m));
        }
    }
}
