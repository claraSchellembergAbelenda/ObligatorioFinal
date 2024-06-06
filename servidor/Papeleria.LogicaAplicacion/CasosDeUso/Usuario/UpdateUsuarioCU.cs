using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Encryption;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class UpdateUsuarioCU : IUpdateUsuarioCU
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public UpdateUsuarioCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public void UpdateUsuario(UsuarioDTO dto, string password, string aValidar)
        {
            Papeleria.LogicaNegocio.Entidades.Usuario aEditar = _repositorioUsuarios.FindByID(dto.Id);
            aEditar.esAdmin=dto.esAdmin;
            aEditar.esEncargado=dto.esEncargado;
            aEditar.nombreCompleto.nombre = dto.nombre;
            aEditar.nombreCompleto.apellido = dto.apellido;
            string temporal = password;

            if(string.IsNullOrEmpty(aValidar) || string.IsNullOrEmpty(password))
            {
                this._repositorioUsuarios.Update(aEditar);
            }
            else
            {
                if (Encriptadora.HashPassword(aValidar) == aEditar.password)
                {
                    aEditar.password = Encriptadora.HashPassword(password);
                    aEditar.passwordSinEncriptar = temporal;
                    this._repositorioUsuarios.Update(aEditar);
                }

                else
                {
                    throw new UsuarioNoValidoException("La contraseña ingresada no es correcta");
                }
            }
        }
    }


}
