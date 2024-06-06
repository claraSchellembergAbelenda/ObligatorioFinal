using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class EncontrarUsuarioPorEmailCU : IEncontrarUsuarioPorEmailCU
    {
        private IRepositorioUsuario _repositorioUsuario;
        public EncontrarUsuarioPorEmailCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDTO EncontrarUsuarioPorEmail(string email)
        {
            UsuarioDTO encontrado =UsuarioDtoMapper.ToDto(_repositorioUsuario.FindByEmail(email));
            if (encontrado != null)
            {
                return encontrado;
            }
            return null;
        }
    }
}
