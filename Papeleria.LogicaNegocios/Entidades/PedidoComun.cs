using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido
    {
        private IRepositorioPedido _repositorioPedido;
        public PedidoComun() { }
        public PedidoComun(Cliente cliente, List<Linea> _lineas, double descuento, DateTime _fechaEntregaDeseada) : base(cliente, _lineas, descuento, _fechaEntregaDeseada)
        {
        }
        public PedidoComun(IRepositorioPedido repositorioPedido)
        {
            this._repositorioPedido = repositorioPedido;
        }

        public override void EsValido()
        {
            try
            {
                ValidarDescuento();
                ValidarDias();
            }
            catch(PedidoComunNoValidoException ex)
            {
                throw new PedidoComunNoValidoException(ex.Message);
            }
            
            
        }
        
        public void ValidarDescuento()
        {
            if (this.descuento > 25)
            {
                throw new PedidoComunNoValidoException("El descuento no puede ser de mas de 25%");
            }
        }
        public void ValidarDias()
        {
            TimeSpan diferencia = this.fechaEntregaDeseada.Subtract(this.fechaPedido);
            int cantidadDias = diferencia.Days;
            if (cantidadDias<7)
            {
                throw new PedidoComunNoValidoException("El pedido comun no puede tener menos de 7 dias para la entrega");
            }
        }
        /*
        public override void CalcularPrecio(double iva, double recargo)
        {
            double subTotal = 0;
           
            foreach(Linea l in _lineas)
            {
                subTotal += l.precioLinea;
            }
            if (recargo>0)
            {
                subTotal =subTotal+( subTotal * (recargo/100));

            }
            subTotal = subTotal - (subTotal * (descuento / 100));
            precioTotal = subTotal + (subTotal * (iva / 100));

        }*/
    }
}
