using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.BusinessLogic.ValueObjects;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class UsuarioDtoMapper
    {
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            return new UsuarioDTO(usuario);
        }
        public static Usuario FromDto(UsuarioDTO dto)
        {
            return new Usuario
            {
                id = dto.Id,
                email = dto.email,
                nombreCompleto = new NombreCompleto(dto.nombre, dto.apellido),
                password = Encriptadora.HashPassword(dto.password),
                passwordSinEncriptar=dto.password,
                esAdmin = dto.esAdmin,
                esEncargado=dto.esEncargado
                // aplicar encriptcacion
            };

        }
    }
}
