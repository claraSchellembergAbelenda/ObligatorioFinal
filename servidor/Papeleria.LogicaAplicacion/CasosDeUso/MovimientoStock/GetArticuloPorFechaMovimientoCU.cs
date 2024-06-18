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
        private IRepositorioSetting _repositorioSetting;
        public GetArticuloPorFechaMovimientoCU(IRepositorioMovimientoStock repoMovimientoStock, IRepositorioSetting repositorioSetting)
        {
            _repoMovimientoStock = repoMovimientoStock;
            _repositorioSetting = repositorioSetting;
        }

        public IEnumerable<ArticuloDTO> GetArticuloPorFechas(DateTime f1, DateTime f2, int numeroDePagina)
        {
            int tamañoPagina = int.Parse(this._repositorioSetting.GetValueByName("TamañoPagina") + "");
            var articulos= _repoMovimientoStock.GetArticuloPorFechaMovimiento(f1, f2, numeroDePagina, tamañoPagina);
           return articulos.Select(a => ArticuloDtoMapper.ToDto(a));
        }
    }
}
