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
    public class CrearUsuarioCU : ICrearUsuarioCU
    {
        private IRepositorioUsuario _repositorioUsuario;
        public CrearUsuarioCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void CrearUsuario(UsuarioDTO dtoACrear)
        {
            this._repositorioUsuario.Add(UsuarioDtoMapper.FromDto(dtoACrear));
        }
    }
}
