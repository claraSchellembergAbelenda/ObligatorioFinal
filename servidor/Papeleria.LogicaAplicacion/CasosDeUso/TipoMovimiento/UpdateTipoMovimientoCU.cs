using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class UpdateTipoMovimientoCU : IUpdateTipoMovientoCU
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public UpdateTipoMovimientoCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void UpdateTipoMoviento(TipoMovimientoDTO dto)
        {
            
            _repositorioTipoMovimiento.Update(TipoMovimientoDtoMapper.FromDto(dto));
        }
    }
}
