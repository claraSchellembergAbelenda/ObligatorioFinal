using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Cliente
{
    public class GetClientesCU : IGetClientesCU
    {
        private IRepositorioCliente _repositorioCliente;
        public GetClientesCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioCliente = repositorioClientes;
        }
        IEnumerable<ClienteDTO> IGetClientesCU.GetClienteDTOs()
        {
            var clientes = _repositorioCliente.FindAll();
            return clientes.Select(c => ClienteDtoMapper.ToDto(c)).ToList();
        }
    }
}
