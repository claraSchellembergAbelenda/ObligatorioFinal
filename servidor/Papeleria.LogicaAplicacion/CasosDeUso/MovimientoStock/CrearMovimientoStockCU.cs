using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
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

        
        private  IRepositorioMovimientoStock _repositorioMovimientoStock;



        public CrearMovimientoStockCU(IRepositorioMovimientoStock repositorioMovimientoStock)
        {
            _repositorioMovimientoStock = repositorioMovimientoStock;
            
        }


        public void CrearMovimiento(MovimientoStockDTO dto) 
        {
            
            
            _repositorioMovimientoStock.Add(MovimientoStockDtoMapper.FromDto(dto));

        }
    }
}
