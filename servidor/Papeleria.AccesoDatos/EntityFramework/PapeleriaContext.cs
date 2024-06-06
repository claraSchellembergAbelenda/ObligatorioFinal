using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidosComunes { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get;set; }
        public DbSet<TipoMovimiento> TiposDeMovimientos {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=ObligatorioPapeleria;Integrated Security=true;");
        }
        
    }
}
