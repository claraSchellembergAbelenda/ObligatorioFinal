using Papeleria.LogicaAplicacion.Mappers;
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
        [ForeignKey(nameof(articuloMovido))] public int articuloMovidoId { get; set; }

        public ArticuloDTO? articuloMovido { get; set; }
        [ForeignKey(nameof(tipoMovimiento))] public int tipoMovimientoId { get; set; }

        public TipoMovimientoDTO? tipoMovimiento { get; set; }
       public string encargadoEmail { get; set; }
        public int cantUnidadesMovidas { get; set; }

        public MovimientoStockDTO() { }
        public MovimientoStockDTO(int id, DateTime fechaYHora, ArticuloDTO articuloMovido, TipoMovimientoDTO tipoMovimiento, UsuarioDTO usuario, int cantUnidadesMovidas)
        {
            this.id = id;
            this.fechaYHora = fechaYHora;
            this.articuloMovido = articuloMovido;
            this.tipoMovimiento = tipoMovimiento;
            //this.usuario = usuario;
            this.cantUnidadesMovidas = cantUnidadesMovidas;
        }

        public MovimientoStockDTO(MovimientoStock movimientoStock)
        {
            this.id = movimientoStock.id;
            this.fechaYHora = movimientoStock.fechaYHora;
            this.articuloMovidoId = movimientoStock.articuloMovidoId;
            this.articuloMovido = ArticuloDtoMapper.ToDto(movimientoStock.articuloMovido);
            this.tipoMovimiento = TipoMovimientoDtoMapper.ToDto(movimientoStock.tipoMovimiento); 
            this.tipoMovimientoId = movimientoStock.tipoMovimientoId;
            //this.usuario = UsuarioDtoMapper.ToDto(movimientoStock.usuario);
            //this.usuarioId = movimientoStock.usuarioId;
            this.encargadoEmail = movimientoStock.encargadoEmail;
            this.cantUnidadesMovidas = movimientoStock.cantUnidadesMovidas;
        }
    }
}
