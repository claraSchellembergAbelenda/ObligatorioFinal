using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Usuarios
{
    public interface IGetUsuariosAscendenteCU
    {
        public List<UsuarioIndexDTO> GetUsuariosOrdenados();
    }
}
