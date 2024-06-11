using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class GetTiposMovimientoCU : IGetTiposMovimientoCU
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public GetTiposMovimientoCU(IRepositorioTipoMovimiento repositorioMovimiento)
        {
            _repositorioTipoMovimiento = repositorioMovimiento;
        }
        public IEnumerable<TipoMovimientoDTO> GetTipoMovimientos()
        {
            return _repositorioTipoMovimiento.FindAll().Select(t => TipoMovimientoDtoMapper.ToDto(t));
        }
    }
}
