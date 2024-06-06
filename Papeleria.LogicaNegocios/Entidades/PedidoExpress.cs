using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.Exceptions.PedidoExpress;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public PedidoExpress() { }
        public PedidoExpress(Cliente cliente, List<Linea> _lineas, double descuento, DateTime _fechaEntregaDeseada) : base(cliente, _lineas, descuento, _fechaEntregaDeseada)
         {
         }

        public override void EsValido()
        {
            try
            {
                ValidarDias();
                ValidarDescuento();
            }
            catch(PedidoExpressNoValidoException ex) 
            {
                throw new PedidoExpressNoValidoException(ex.Message);
            }
            
        }
        public void ValidarDescuento()
        {
            if (this.descuento > 25)
            {
                throw new PedidoExpressNoValidoException("El descuento no puede ser de mas de 25%");
            }
        }
        public void ValidarDias()
        {
            TimeSpan diferencia = this.fechaEntregaDeseada.Subtract(this.fechaPedido);
            int cantidadDias = diferencia.Days;
            if (cantidadDias >5)
            {
                throw new PedidoExpressNoValidoException("El pedido comun no puede tener mas de 5 dias para la entrega");
            }
        }
        /*
        public override void CalcularPrecio(double iva, double recargo)
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
            
            subTotal = subTotal - (subTotal * (descuento / 100));
            precioTotal = subTotal + (subTotal * (iva / 100));

        }*/
    }
}
