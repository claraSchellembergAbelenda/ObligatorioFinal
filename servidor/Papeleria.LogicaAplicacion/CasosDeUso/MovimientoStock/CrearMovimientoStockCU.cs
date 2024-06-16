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
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;

namespace Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock
{
    public class CrearMovimientoStockCU : ICrearMovimientoStockCU
    {

        
        private  IRepositorioMovimientoStock _repositorioMovimientoStock;
        private IRepositorioSetting _repositorioSetting;



        public CrearMovimientoStockCU(IRepositorioMovimientoStock repositorioMovimientoStock, IRepositorioSetting repositorioSetting)
        {
            _repositorioMovimientoStock = repositorioMovimientoStock;
            _repositorioSetting = repositorioSetting;
        }


        public void CrearMovimiento(MovimientoStockDTO dto) 
        {
            double tope = _repositorioSetting.GetValueByName("topeStock");
            
            if (dto.cantUnidadesMovidas > tope)
            {
                
                throw new MovimientoStockNoValidoException("La cantidad de unidades no puede superar " + tope);
            }
        
            else
            {
            _repositorioMovimientoStock.Add(MovimientoStockDtoMapper.FromDto(dto));
            }
            
        }
    }
}
