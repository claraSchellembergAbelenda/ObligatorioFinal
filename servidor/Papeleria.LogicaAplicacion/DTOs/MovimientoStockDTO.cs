using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class MovimientoStockDTO
    {
        public int id { get; set; }
        public DateTime fechaYHora { get; set; }
        public ArticuloDTO articuloMovido { get; set; }

        public TipoMovimientoDTO tipoMovimiento { get; set; }
        public UsuarioDTO usuario { get; set; }
        public int cantUnidadesMovidas { get; set; }

        public MovimientoStockDTO() { }
        public MovimientoStockDTO(int id, DateTime fechaYHora, ArticuloDTO articuloMovido, TipoMovimientoDTO tipoMovimiento, UsuarioDTO usuario, int cantUnidadesMovidas)
        {
            this.id = id;
            this.fechaYHora = fechaYHora;
            this.articuloMovido = articuloMovido;
            this.tipoMovimiento = tipoMovimiento;
            this.usuario = usuario;
            this.cantUnidadesMovidas = cantUnidadesMovidas;
        }

        public MovimientoStockDTO(MovimientoStock movimientoStock)
        {
        }
    }
}
