using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Cliente : IValidable<Cliente>
    {
        
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string rut { get; set; }
        public Direccion adress { get; set; }
        public double distancia { get; set; }
        public NombreCompletoClientes nombreCompleto { get; set; }
        public Cliente() { }
        public Cliente(string razonSocial, string rut, Direccion direccion,double distancia, NombreCompletoClientes nombreCompletoCli)
        {
            this.razonSocial = razonSocial;
            this.rut = rut;
            this.adress = direccion;
            this.distancia = distancia;
            this.nombreCompleto = nombreCompletoCli;
        }
        public Cliente(int id,string razonSocial, string rut, string calle,  string puerta, string ciudad, double distancia, string nombre, string apellido)
        {
            this.id = id;
            this.razonSocial = razonSocial;
            this.rut = rut;
            adress = new Direccion(calle, puerta, ciudad);
            this.distancia = distancia;
            nombreCompleto = new NombreCompletoClientes(nombre, apellido);
        }

        public void EsValido()
        {
            try
            {
                ValidarRUT();
            }
            catch(ClienteNoValidoException ex)
            {
                throw new ClienteNoValidoException(ex.Message);
            }
        }

        public void ValidarRUT()
        {
            if (this.rut.Length != 12)
            {
                throw new ClienteNoValidoException("El rut debe tener 12 digitos");
            }
        }
    }
}
