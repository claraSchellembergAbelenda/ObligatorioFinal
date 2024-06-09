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
    public class FindTipoMovimientoCU : IFindTipoMovimientoCU
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public FindTipoMovimientoCU(IRepositorioTipoMovimiento repositorioMovimiento)
        {
            _repositorioTipoMovimiento = repositorioMovimiento;
        }
        public TipoMovimientoDTO FindTipoMovimiento(int id)
        {
           return  TipoMovimientoDtoMapper.ToDto(_repositorioTipoMovimiento.FindByID(id));
        }
    }
}
