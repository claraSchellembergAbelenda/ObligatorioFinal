using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mapper;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class GetUsuariosAscendenteCU : IGetUsuariosAscendenteCU
    { 
        //Inyeccion de dependencia
        private IRepositorioUsuario _repositorioUsuarios;

        public GetUsuariosAscendenteCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public List<UsuarioIndexDTO> GetUsuariosOrdenados()
        {
            var usuarios = _repositorioUsuarios.FindAll().OrderBy(u => u.nombreCompleto.apellido);

            return usuarios.Select(u => UsuarioIndexDtoMapper.ToDto(u)).ToList();


        }
    }
}
