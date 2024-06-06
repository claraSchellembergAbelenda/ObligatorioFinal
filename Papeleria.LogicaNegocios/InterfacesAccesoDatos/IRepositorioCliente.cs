using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesAccesoDatos { 
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> BuscarEnClientes(string criterio);
        IEnumerable<Cliente> ClientesCuyoPedidoSupereMonto(double monto);

    }
}
