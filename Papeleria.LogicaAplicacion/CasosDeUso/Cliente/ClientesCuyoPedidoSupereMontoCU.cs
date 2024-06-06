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
    public class ClientesCuyoPedidoSupereMontoCU : IClientesCuyoPedidoSupereMontoCU
    {
        private IRepositorioCliente _repositorioClientes;
        

        public ClientesCuyoPedidoSupereMontoCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }


        IEnumerable<ClienteDTO> IClientesCuyoPedidoSupereMontoCU.ClientesCuyoPedidoSupereMonto(double monto)
        {
            var clientes= _repositorioClientes.ClientesCuyoPedidoSupereMonto(monto);
            return clientes.Select(c => ClienteDtoMapper.ToDto(c)).ToList();
        }
    }
    
    }

