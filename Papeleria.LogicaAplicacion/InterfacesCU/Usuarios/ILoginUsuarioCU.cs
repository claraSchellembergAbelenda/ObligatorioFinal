using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Usuarios
{
    public interface ILoginUsuarioCU
    {
        public UsuarioDTO LoginUsuario(string correo, string contraseña);
    }
}
