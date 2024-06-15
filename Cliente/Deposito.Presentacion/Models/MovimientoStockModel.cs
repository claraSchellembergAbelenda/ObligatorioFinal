using System.ComponentModel.DataAnnotations.Schema;

namespace Deposito.Presentacion.Models
{
    public class MovimientoStockModel
    {
        public int id { get; set; }
        public DateTime fechaYHora { get; set; }
        [ForeignKey(nameof(articuloMovido))] public int articuloMovidoId { get; set; }

        public ArticuloModel? articuloMovido { get; set; }
        [ForeignKey(nameof(tipoMovimiento))] public int tipoMovimientoId { get; set; }

        public TipoMovimientoModel? tipoMovimiento { get; set; }
        [ForeignKey(nameof(usuario))] public int usuarioId { get; set; }

        public UsuarioModel? usuario { get; set; }
        public int cantUnidadesMovidas { get; set; }

    }
}
