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
    public class GetAllMovimientosCU : IGetAllMovimientosCU
    {
        private IRepositorioMovimientoStock _repoMovements;
        public GetAllMovimientosCU(IRepositorioMovimientoStock repositorioMovimientoStock)
        {
            this._repoMovements=repositorioMovimientoStock;
        }
        IEnumerable<MovimientoStockDTO> IGetAllMovimientosCU.GetAllMovimientosCU()
        {
            var movimientos=_repoMovements.FindAll();
            return movimientos.Select(m => MovimientoStockDtoMapper.ToDto(m));
        }
    }
}
