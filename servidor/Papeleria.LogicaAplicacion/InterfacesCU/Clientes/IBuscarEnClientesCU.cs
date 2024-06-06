using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Clientes
{
    public interface IBuscarEnClientesCU
    {
        public IEnumerable<ClienteDTO> BuscarEnClientes(string criterio);
    }
}
