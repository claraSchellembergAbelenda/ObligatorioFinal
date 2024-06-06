using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class GetPedidosAnuladosDescCU : IGetPedidosAnuladosDescCU
    {
        private IRepositorioPedido _repositorioPedido;
        private IRepositorioCliente _repositorioCliente;
        private IRepositorioLinea _repositorioLinea;
        public GetPedidosAnuladosDescCU(IRepositorioPedido repositorioPedido, IRepositorioCliente repositorioCliente,
            IRepositorioLinea repositorioLinea) 
        {
            this._repositorioPedido = repositorioPedido;
            this._repositorioCliente = repositorioCliente;
            this._repositorioLinea = repositorioLinea;
        }
        public List<PedidoDTO> GetPedidosAnuladosDesc()
        {
            List<LogicaNegocio.Entidades.Pedido> pedidosAnulados = _repositorioPedido.GetPedidosAnuladosDesc();
            pedidosAnulados.ForEach(CargarDatosPedido);
            return pedidosAnulados.Select(p => PedidoDtoMapper.ToDto(p)).ToList();
        }
        private void CargarDatosPedido(LogicaNegocio.Entidades.Pedido p)
        {
            p.cliente = _repositorioCliente.FindByID(p.clienteId);
            p._lineas = _repositorioLinea.FindByPedidoId(p.id);
        }
    }
}
