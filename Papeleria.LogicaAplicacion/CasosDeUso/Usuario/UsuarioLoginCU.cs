using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Encryption;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.InterfacesUC;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso
{
    public class UsuarioLoginCU : ILoginUsuarioCU
    {
        public IRepositorioUsuario _repositorioUsuario;
        public UsuarioLoginCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }


        public UsuarioDTO LoginUsuario(string mail, string passwordNoEncriptada)
        {
            Papeleria.LogicaNegocio.Entidades.Usuario encontrado = _repositorioUsuario.FindByEmail(mail);
            string passwordEncriptada = Encriptadora.HashPassword(passwordNoEncriptada);
            UsuarioDTO dto = UsuarioDtoMapper.ToDto(encontrado);
            if (encontrado != null && encontrado.password == passwordEncriptada)
            {
                return dto;
            }
            else
            {
                return null;
            }

        }
    }
}
