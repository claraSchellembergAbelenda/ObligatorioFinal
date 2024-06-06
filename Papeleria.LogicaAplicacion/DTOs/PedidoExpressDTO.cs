using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoExpressDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public Cliente cliente { get; set; }
        public Linea lineas { get; set; }
        public double precioTotal { get; set; }
        public double descuento { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public PedidoExpressDTO(DateTime fechaPedido, ClienteDTO cliente, LineaDTO lineas, double precioTotal, double descuento, EstadoPedido estadoPedido)
        {
        }
        public PedidoExpressDTO(PedidoExpress pedidoExpress)
        {
            if (pedidoExpress != null)
            {
                id = pedidoExpress.id;
                cliente = pedidoExpress.cliente;
                fechaPedido = pedidoExpress.fechaPedido;
            }
        }
        public PedidoExpressDTO() { }
    }
}
