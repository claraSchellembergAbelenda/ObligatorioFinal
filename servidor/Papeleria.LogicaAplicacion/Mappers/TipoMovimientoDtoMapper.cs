using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class TipoMovimientoDtoMapper
    {
        public static TipoMovimientoDTO ToDto(TipoMovimiento tp)
        {
            return new TipoMovimientoDTO(tp);
        }
        public static TipoMovimiento FromDto(TipoMovimientoDTO dto)
        {
            if (dto == null)
            {
                throw new TipoMovimientoNoValidoException("Articulo es null");
            }
            return new TipoMovimiento(dto.id, dto.nombreMovimiento, dto.esPositivo);
        }
    }
}