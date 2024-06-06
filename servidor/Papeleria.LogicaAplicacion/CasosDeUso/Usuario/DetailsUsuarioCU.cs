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
    public class DetailsUsuarioCU : IDetailsUsuarioCU
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public DetailsUsuarioCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public UsuarioDTO DetailsUsuario(int id)
        {
            UsuarioDTO u = UsuarioDtoMapper.ToDto(this._repositorioUsuarios.FindByID(id));
            return u;
        }
    }
}
