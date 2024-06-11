namespace Deposito.Presentacion.Models
{
    public class MovimientoStockModel
    {
        public int id { get; set; }
        public DateTime fechaYHora { get; set; }
        public ArticuloModel articuloMovido { get; set; }

        public TipoMovimientoModel tipoMovimiento { get; set; }
        public UsuarioModel usuario { get; set; }
        public int cantUnidadesMovidas { get; set; }

    }
}
