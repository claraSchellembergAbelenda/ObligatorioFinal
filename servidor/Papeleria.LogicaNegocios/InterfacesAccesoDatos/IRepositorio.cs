using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesAccesoDatos
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        bool Add(T aAgregar);
        bool Remove(int id);
        bool Update(T aModificar);
    }
}
