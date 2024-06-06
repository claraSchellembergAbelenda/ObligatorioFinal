using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class ArticuloDtoMapper
    {
        public static ArticuloDTO ToDto(Articulo articulo)
        {
            return new ArticuloDTO(articulo);
        }
        public static Articulo FromDto(ArticuloDTO dto)
        {
            if (dto == null)
            {
                throw new ArticuloNoValidoException("Articulo es null");
            }
            return new Articulo(dto.id, dto.nombre, dto.descripcion, dto.codProveedor, dto.precioActual, dto.stock);
        }
    }
}
