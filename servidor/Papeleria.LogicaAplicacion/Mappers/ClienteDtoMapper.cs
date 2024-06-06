using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class ClienteDtoMapper
    {
        public static ClienteDTO ToDto(Cliente cliente)
        {
            return new ClienteDTO(cliente);
        }
        public static Cliente FromDto(ClienteDTO dto)
        {
            if (dto == null)
            {
                throw new ClienteNoValidoException();
            }
            return new Cliente(dto.id, dto.razonSocial, dto.rut, dto.calle, dto.numeroPuerta, dto.ciudad, dto.distancia, dto.nombre, dto.apellido);
        }
    }
}
