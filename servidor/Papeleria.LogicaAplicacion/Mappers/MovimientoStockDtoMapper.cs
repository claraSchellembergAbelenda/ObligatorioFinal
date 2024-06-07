using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class MovimientoStockDtoMapper
    {
        public static MovimientoStockDTO ToDto(MovimientoStock movimientoStock)
        {
            return new MovimientoStockDTO(movimientoStock);
        }
        public static MovimientoStock FromDto(MovimientoStockDTO dto)
        {
            if (dto == null)
            {
                throw new MovimientoStockNoValidoException("Articulo es null");
            }
            Usuario u = UsuarioDtoMapper.FromDto(dto.usuario);
            Articulo a = ArticuloDtoMapper.FromDto(dto.articuloMovido);
            TipoMovimiento tp = TipoMovimientoDtoMapper.FromDto(dto.tipoMovimiento);
            return new MovimientoStock(dto.id, dto.fechaYHora, a, tp, u, dto.cantUnidadesMovidas);
        }
    }
}
