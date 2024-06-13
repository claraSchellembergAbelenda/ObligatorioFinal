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
    public class CrearTipoMovimientoCU : ICrearTipoMovimientoCU
    {
        private IRepositorioTipoMovimiento  _repositorioTipoMovimiento;
        public CrearTipoMovimientoCU(IRepositorioTipoMovimiento repositorioMovimiento) 
        {
            _repositorioTipoMovimiento = repositorioMovimiento;
        }
        public void CrearTipoMovimiento(TipoMovimientoDTO dtoACrear)
        {
            this._repositorioTipoMovimiento.Add(TipoMovimientoDtoMapper.FromDto(dtoACrear));
        }
    }
}
