using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string rut { get; set; }
        public string calle { get; set; }
        public string numeroPuerta { get; set; }
        public string ciudad { get; set; }
        public double distancia { get; set; }
        public string nombre { get; set; }
        public string apellido {  get; set; }
        public ClienteDTO() { }
        public ClienteDTO(int id, string razonSocial, string rut, string calle, string numeroPuerta, string ciudad, double distancia, string nombre, string apellido)
        {
            this.id = id;
            this.razonSocial = razonSocial;
            this.rut = rut;
            this.calle = calle;
            this.numeroPuerta = numeroPuerta;
            this.ciudad = ciudad;
            this.distancia = distancia;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public ClienteDTO(Cliente cliente)
        {
            if (cliente != null)
            {
                id = cliente.id;
                razonSocial = cliente.razonSocial;
                rut = cliente.rut;
                calle = cliente.adress.calle;
                numeroPuerta = cliente.adress.numeroPuerta;
                ciudad = cliente.adress.ciudad;
                distancia = cliente.distancia;
                nombre = cliente.nombreCompleto.nombre;
                apellido = cliente.nombreCompleto.apellido;
            }
        }
    }
}
