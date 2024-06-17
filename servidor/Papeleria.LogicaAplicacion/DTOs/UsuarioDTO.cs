using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public bool? esAdmin {  get; set; }
        public bool? esEncargado { get; set; }
        public UsuarioDTO() { }
        public UsuarioDTO(int id, string Email, string Password, string? Nombre, string? Apellido)
        {
            Id = id;
            email = Email;
            password = Password;
            nombre = Nombre;
            apellido = Apellido;
        }
        public UsuarioDTO(string Email, string Password)
        {
            email = Email;
            password = Password;
        }
        public UsuarioDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                Id = usuario.id;
                email = usuario.email;
                password = usuario.password;
                nombre = usuario.nombreCompleto.nombre;
                apellido = usuario.nombreCompleto.apellido;
                esAdmin = usuario.esAdmin;
                esEncargado = usuario.esEncargado;
            }
        }
    }
}
