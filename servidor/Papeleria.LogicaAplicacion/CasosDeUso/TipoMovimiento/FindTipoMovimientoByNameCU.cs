using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento
{
    public class FindTipoMovimientoByNameCU : IFindTipoMovimientoByNameCU
    {
        private IRepositorioTipoMovimiento _repoTipoMovimiento;
        public FindTipoMovimientoByNameCU(IRepositorioTipoMovimiento repoTipoMovimiento)
        {
            _repoTipoMovimiento = repoTipoMovimiento;
        }

        public TipoMovimientoDTO FindTipoMovimientoByName(string name)
        {
            LogicaNegocios.Entidades.TipoMovimiento encontrado = _repoTipoMovimiento.FindTipoMovimientoByName(name);
            if(encontrado == null)
            {
                throw new TipoMovimientoNoValidoException("el tipo de movimiento que usted ingreso no es valido, por favor trate de nuevo");
            }
            return TipoMovimientoDtoMapper.ToDto(encontrado);
        }
    }
}
