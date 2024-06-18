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
        private IRepositorioSetting _repositorioSetting;
        public GetPorTipoMovimientoYArticuloCU(IRepositorioMovimientoStock repoMovimientoStock, IRepositorioSetting repositorioSetting)
        {
            _repoMovimientoStock = repoMovimientoStock;
            _repositorioSetting = repositorioSetting;
        }





        public IEnumerable<MovimientoStockDTO> GetPorTipoMovimientoYArticulo(int idArticulo, string tipo, int numeroDePagina)
        {
            int tamañoPagina = int.Parse(this._repositorioSetting.GetValueByName("TamañoPagina") + "");

            var movimientos =_repoMovimientoStock.GetPorTipoYArticulo(idArticulo, tipo, numeroDePagina, tamañoPagina);

            return movimientos.Select(m => MovimientoStockDtoMapper.ToDto(m));
        }
    }
}
