namespace Deposito.Presentacion.Models
{
    public class ArticuloModel
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codProveedor { get; set; }
        public double precioActual { get; set; }
        public int stock { get; set; }
        public int id { get; set; }
    }
}
