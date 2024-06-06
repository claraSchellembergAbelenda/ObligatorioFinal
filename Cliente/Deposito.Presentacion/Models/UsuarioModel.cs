namespace Deposito.Presentacion.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public bool esAdmin { get; set; }
        public bool esEncargado { get; set; }
    }
}
