using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesAccesoDatos
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        IEnumerable<Articulo> GetArticulosOrdenadosAlfabeticamente();
    }
}
