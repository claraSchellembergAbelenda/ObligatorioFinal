using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects
{
    [Owned]
    public class Direccion : IValidable<Direccion>
    {
        public string calle { get; set; }
        public string numeroPuerta { get; set; }
        public string ciudad { get; set; }
        public Direccion() { }
        public Direccion(string calle, string numeroPuerta, string ciudad)
        {
            this.calle = calle;
            this.numeroPuerta = numeroPuerta;
            this.ciudad = ciudad;
        }

        public void EsValido()
        {
            if(string.IsNullOrEmpty(calle)|| string.IsNullOrEmpty(numeroPuerta)|| string.IsNullOrEmpty(ciudad))
            {
                throw new ClienteNoValidoException("direccion invalida, por favor asegurese de ingresar todos los campos");
            }
        }
    }
}
