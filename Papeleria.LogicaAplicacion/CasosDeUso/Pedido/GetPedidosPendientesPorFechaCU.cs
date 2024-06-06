using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class GetPedidosPendientesPorFechaCU : IGetPedidosPendientesPorFechaCU
    {
        private IRepositorioPedido _repositorioPedido;

        public GetPedidosPendientesPorFechaCU(IRepositorioPedido repositorioPedido)
        {
            this._repositorioPedido = repositorioPedido;
        }
        public IEnumerable<PedidoDTO> GetPedidosPendientesPorFecha(DateTime fecha)
        {
            var pendientes = _repositorioPedido.GetPedidosPendientesPorFecha(fecha);
            var pendientesEntidad = pendientes.Select(p => PedidoDtoMapper.ToDto(p)).ToList();
            return pendientesEntidad;
        }
    }
}
