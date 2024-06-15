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
    public class EncontrarUsuarioPorIdCU : IEncontrarUsuarioPorIdCU
    {
        private IRepositorioUsuario _repositorioUsuario;
        public EncontrarUsuarioPorIdCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDTO EncontrarUsuarioPorId(int id)
        {
            UsuarioDTO encontrado =UsuarioDtoMapper.ToDto(_repositorioUsuario.FindByID(id));
            if (encontrado != null)
            {
                return encontrado;
            }
            return null;
        }
    }
}
