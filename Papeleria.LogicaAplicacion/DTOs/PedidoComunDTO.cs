using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoComunDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public ClienteDTO cliente { get; set; }
        public LineaDTO lineas { get; set; }
        public double precioTotal { get; set; }
        public double descuento { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public PedidoComunDTO(DateTime fechaPedido, ClienteDTO cliente, LineaDTO lineas, double precioTotal, double descuento, EstadoPedido estadoPedido)
        {
        }
        public PedidoComunDTO() { }
        public PedidoComunDTO(PedidoComun pedidoComun)
        {
            if (pedidoComun != null)
            {
                ClienteDTO nuevoCliente =ClienteDtoMapper.ToDto (pedidoComun.cliente);
                id = pedidoComun.id;
                cliente = nuevoCliente;
                fechaPedido = pedidoComun.fechaPedido;
            }
        }
    }
}
