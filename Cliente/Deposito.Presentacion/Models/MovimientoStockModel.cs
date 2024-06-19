using System.ComponentModel.DataAnnotations.Schema;

namespace Deposito.Presentacion.Models
{
    public class MovimientoStockModel
    {
        public int id { get; set; }
        public DateTime fechaYHora { get; set; }
        public int articuloMovidoId { get; set; }

        public ArticuloModel? articuloMovido { get; set; }
        public int tipoMovimientoId { get; set; }

        public TipoMovimientoModel? tipoMovimiento { get; set; }
        public string encargadoEmail { get; set; }

        public int cantUnidadesMovidas { get; set; }

    }
}
