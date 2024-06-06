using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public ClienteDTO cliente { get; set; }
        public int clienteId { get; set; }
        public List<LineaDTO> _lineas { get; set; }
        public double precioTotal { get; set; }
        public double descuento { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public DateTime fechaEntregaDeseada { get; set; }
        public string pedidoElegido { get; set; }
        public void AddLinea(LineaDTO lineaDTO)
        {
            try
            {
                Linea linea = LineaDtoMapper.FromDto(lineaDTO);
                linea.EsValido();
                _lineas.Add(lineaDTO);
            }
            catch(LineaNoValidaException ex)
            {
                throw new LineaNoValidaException(ex.Message);
            }
        }
        public PedidoDTO() { }
        public PedidoDTO(Pedido pedido)
        {
            if(pedido != null)
            {
                this.id=pedido.id;
                this.fechaPedido = pedido.fechaPedido;
                this.cliente = new ClienteDTO(pedido.cliente);
                if(_lineas != null)
                {
                    this._lineas = pedido._lineas.Select(linea => new LineaDTO(linea)).ToList();
                }
                this.precioTotal = pedido.precioTotal;
                this.descuento = pedido.descuento;
                this.estadoPedido = pedido.estadoPedido;
                this.estadoPedido = pedido.estadoPedido;
                this.fechaEntregaDeseada = pedido.fechaEntregaDeseada;
            }
            
        }
    }
}
