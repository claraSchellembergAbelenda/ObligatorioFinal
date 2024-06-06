using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Clientes
{
    public interface IGetClientesCU
    {
        public IEnumerable<ClienteDTO> GetClienteDTOs();
    }
}
