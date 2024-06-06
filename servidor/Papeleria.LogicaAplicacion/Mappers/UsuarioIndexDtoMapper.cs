using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mapper
{
    public class UsuarioIndexDtoMapper
    {

        public static UsuarioIndexDTO ToDto(Usuario usuario)
        {

            return new UsuarioIndexDTO(usuario);


        }

        public static Usuario FromDto(UsuarioIndexDTO dto)
        {

            return new Usuario
            {
                id = dto.id,
                email = dto.email,
                nombreCompleto = new NombreCompleto(dto.nombre, dto.apellido),
                esAdmin = dto.esAdmin,
                esEncargado=dto.esEncargado
                // aplicar encriptcacion
            };
        }
    }
}
