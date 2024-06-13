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
    public class CrearMovimientoStockCU : ICrearMovimientoStockCU
    {

        private IRepositorioMovimientoStock _repositorioMovimientoStock;

        public CrearMovimientoStockCU(IRepositorioMovimientoStock repositorio)
        {
            _repositorioMovimientoStock = repositorio;
        }


        public void CrearMovimiento(MovimientoStockDTO dto) 
        {
            _repositorioMovimientoStock.Add(MovimientoStockDtoMapper.FromDto(dto));

        }
    }
}
