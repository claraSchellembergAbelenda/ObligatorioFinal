using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class UsuarioIndexDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public bool? esAdmin { get; set; }

        public bool? esEncargado { get; set; }
        public UsuarioIndexDTO() { }

        public UsuarioIndexDTO(Usuario usuario)
        {
            this.id = usuario.id;
            this.email = usuario.email;
            this.nombre = usuario.nombreCompleto.nombre;
            this.apellido = usuario.nombreCompleto.apellido;
            this.esAdmin = usuario.esAdmin;
            this.esEncargado = usuario.esEncargado;

        }

    }
}
