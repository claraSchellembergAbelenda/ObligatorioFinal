namespace Deposito.Presentacion.Models
{
    public class ResumenMovimientosModel
    {
        public int Año { get; set; }
        public string NombreTipoMovimientos { get; set; }
        public int TotalCantidadesMovidas { get; set; }
        public List<MovimientosTipoAñoModel> movimientos { get; set; }
    }
}
