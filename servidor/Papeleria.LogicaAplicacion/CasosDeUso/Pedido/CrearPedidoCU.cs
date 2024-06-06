using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.Exceptions.PedidoExpress;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class CrearPedidoCU : ICrearPedidoCU
    {
        private IRepositorioPedido _repositorioPedidos;
        private IRepositorioSetting _repositorioSetting;
        public CrearPedidoCU(IRepositorioPedido repositorioPedidos, IRepositorioSetting repositorioSetting)
        {
            _repositorioPedidos=repositorioPedidos;
            _repositorioSetting = repositorioSetting;
        }

        public void CrearPedido(PedidoDTO dto)
        {
            dto.fechaPedido = DateTime.Now;
            TimeSpan diferencia = dto.fechaEntregaDeseada.Subtract(dto.fechaPedido);
            int cantidadDias = Convert.ToInt32(diferencia.TotalDays);
            Papeleria.LogicaNegocio.Entidades.Pedido nuevoPedido = null;
            double recargo = 0;
            if (cantidadDias <= 0)
            {
                throw new Exception("debe seleccionar una fecha en el futuro");
            }
            if (dto.pedidoElegido == "pedidoExpress")
            {
                /*
                if ( dto.pedidoElegido != "pedidoExpress")
                {
                    throw new PedidoComunNoValidoException("pedido express debe tener un maximo de 5 dias");
                }
                */
                if (cantidadDias == 1)
                    recargo = _repositorioSetting.GetValueByName("Recargo EntregaMismoDia");
                else 
                    recargo = _repositorioSetting.GetValueByName("Recargo pedidoExpress");
               
                nuevoPedido = PedidoDtoMapper.ToPedidoExpress(dto);
            }
            else
            {
                /*if (dto.pedidoElegido != "pedidoComun")
                {
                    throw new PedidoExpressNoValidoException("pedido comun debe tener un minimo de 7 dias");
                }*/
                double distancia = _repositorioSetting.GetValueByName("DistanciaCliente");
                if (dto.cliente.distancia > distancia)
                    recargo = _repositorioSetting.GetValueByName("RecargoComun");

                nuevoPedido = PedidoDtoMapper.ToPedidoComun(dto);
            }
            double iva = _repositorioSetting.GetValueByName("IVA");
            nuevoPedido.CalcularPrecio(iva, recargo);
            _repositorioPedidos.Add(nuevoPedido);
            
        }

        
    }
}
