using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;
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
        private IRepositorioMovimientoStock _repositorioMovimientoStock;
        public UpdateTipoMovimientoCU(IRepositorioTipoMovimiento repositorioTipoMovimiento, IRepositorioMovimientoStock repositorioMovimientoStock)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
            _repositorioMovimientoStock = repositorioMovimientoStock;
        }
        public void UpdateTipoMoviento(TipoMovimientoDTO dto)
        {
            LogicaNegocios.Entidades.TipoMovimiento tipo = TipoMovimientoDtoMapper.FromDto(dto);
            if(_repositorioMovimientoStock.ExisteTipo(tipo.nombreMovimiento))
            {
                throw new TipoMovimientoNoValidoException("No puede editar un tipo de movimiento que esta en uso");
            }
            _repositorioTipoMovimiento.Update(tipo);
        }
    }
}
