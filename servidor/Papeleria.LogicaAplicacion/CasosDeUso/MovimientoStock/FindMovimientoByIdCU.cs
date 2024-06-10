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
    public class FindMovimientoByIdCU : IFindMovimientoByIdCU
    {
        private IRepositorioMovimientoStock _repoMovimientoStock;
        public FindMovimientoByIdCU(IRepositorioMovimientoStock repoMovimientoStock)
        {
            _repoMovimientoStock = repoMovimientoStock;
        }

        public MovimientoStockDTO FindMovimientoById(int id)
        {
            return MovimientoStockDtoMapper.ToDto(_repoMovimientoStock.FindByID(id));
            
        }
    }
}
