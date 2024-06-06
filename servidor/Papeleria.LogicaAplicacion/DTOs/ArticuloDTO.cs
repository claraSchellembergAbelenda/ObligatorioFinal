using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ArticuloDTO
    {
        private Articulo articulo;

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codProveedor { get; set; }
        public double precioActual { get; set; }
        public int stock {  get; set; }
        public int id { get; set; }
        public ArticuloDTO() { }
        public ArticuloDTO(int id,string nombre, string descripcion, string codProveedor, double precioActual, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codProveedor = codProveedor;
            this.precioActual = precioActual;
            this.stock = stock; 
        }

        public ArticuloDTO(Articulo articulo)
        {
            if (articulo != null)
            {
                id = articulo.id;
                nombre = articulo.nombre;
                descripcion = articulo.descripcion;
                codProveedor = articulo.codProveedor;
                precioActual = articulo.precioActual;
                stock = articulo.stock;

            }
        }
    }
}
