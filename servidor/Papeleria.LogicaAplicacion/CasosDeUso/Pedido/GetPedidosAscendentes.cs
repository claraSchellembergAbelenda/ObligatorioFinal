using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.Mapper;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class GetPedidosAscendentes : IGetPedidosAscendentes
    {
        private IRepositorioPedido _repositorioPedido;

        public GetPedidosAscendentes(IRepositorioPedido repositorioPedido)
        {
            this._repositorioPedido = repositorioPedido;
        }
       
        List<PedidoDTO> IGetPedidosAscendentes.GetPedidosAsc()
        {
            var pedidosOrdenados = _repositorioPedido.FindAll().OrderBy(p => p.fechaPedido);
            return pedidosOrdenados.Select(p => PedidoDtoMapper.ToDto(p)).ToList();
        }
    }
}
