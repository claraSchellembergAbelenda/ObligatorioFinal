using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocios.InterfacesAccesoDatos
{
    public interface IRepositorioMovimientoStock : IRepositorio<MovimientoStock>
    {
        public IEnumerable<Articulo> GetArticuloPorFechaMovimiento(DateTime f1, DateTime f2, int numeroDePagina, int tamañoPagina);
        public IEnumerable<MovimientoStock> GetPorTipoYArticulo(int idArticulo, string tipo, int numeroPagina, int tamañoPagina);
        public bool ExisteTipo(string tipo);
    }
}
