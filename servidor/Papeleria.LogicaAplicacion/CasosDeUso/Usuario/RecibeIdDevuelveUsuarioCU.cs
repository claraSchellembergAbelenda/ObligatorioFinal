using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class RecibeIdDevuelveUsuarioCU : IRecibeIdDevuelveUsuarioCU
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public RecibeIdDevuelveUsuarioCU(IRepositorioUsuario repositorioUsuarios) 
        {
            _repositorioUsuarios = repositorioUsuarios;
        }
        public UsuarioDTO RecibeIdDevuelveUsuario(int idUsuario)
        {
            Papeleria.LogicaNegocio.Entidades.Usuario u = _repositorioUsuarios.FindByID(idUsuario);
            return UsuarioDtoMapper.ToDto(u);
        }
    }
}
