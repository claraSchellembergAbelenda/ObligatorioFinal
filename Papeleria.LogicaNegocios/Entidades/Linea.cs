using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Linea : IValidable<Linea>
    {
        public int Id { get; set; }
        [ForeignKey(nameof(articulo))] public int articuloId { get; set; }
        public Articulo articulo { get; set; }
        public int cantUnidades { get; set; }
        public double precioLinea { get; set; }
        [ForeignKey(nameof(pedido))] public int pedidoId { get; set; }
        public Pedido pedido { get; set;}
        public Linea() { }
        public Linea(Articulo articulo, int cantUnidades)
        {
            this.articulo = articulo;
            this.cantUnidades = cantUnidades;
            this.precioLinea = CalcularPrecio();
        }

        public void EsValido()
        {
            if (!ValidarStock())
            {
                throw new LineaNoValidaException("no puede ingresar cantidad de unidades mayor al stock disponible");
            }
            
        }
        public bool ValidarStock()
        {
            //validar que para articulo de las lineas haya un stock mayor a 0
            int stock = this.articulo.stock;
            if (stock <= 0 && cantUnidades<stock)
            {
                throw new LineaNoValidaException("no puede ingresar cantidad de unidades mayor al stock disponible");
            }
            return true;

        }
        public double CalcularPrecio()
        {
            this.precioLinea = 0;
            this.precioLinea = articulo.precioActual * cantUnidades;
            return precioLinea;

        }
    }
}
