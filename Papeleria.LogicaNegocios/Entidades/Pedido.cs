using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public abstract class Pedido : IValidable<Pedido>
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        [ForeignKey(nameof(cliente))] public int clienteId { get; set; }
        public Cliente cliente { get; set; }
        public List<Linea> _lineas { get; set; }
        public double precioTotal { get; set; }
        public double descuento {  get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public DateTime fechaEntregaDeseada { get; set; }
        public Pedido() { }

        
        public Pedido(Cliente cliente, List<Linea> _lineas, double descuento, DateTime _fechaEntregaDeseada) { 
            //todo: datetime.now
            this.fechaPedido = DateTime.Now;
            this.cliente = cliente;
            this._lineas = _lineas;
            this.descuento = descuento;
            this.estadoPedido = EstadoPedido.Pendiente;
            this.fechaEntregaDeseada = _fechaEntregaDeseada;
            this.precioTotal= 0;

        }


        public abstract void EsValido();
        public virtual void CalcularPrecio(double iva, double recargo) 
        {
            double subTotal = 0;

            foreach (Linea l in _lineas)
            {
                subTotal += l.precioLinea;
            }

            if (recargo > 0)
            {
                subTotal = subTotal + (subTotal * (recargo / 100));

            }
            /*desceunto*/
            subTotal = subTotal - (subTotal * (descuento / 100));
            /*iva*/
            precioTotal = subTotal + (subTotal * (iva / 100));
        }
    }
}
