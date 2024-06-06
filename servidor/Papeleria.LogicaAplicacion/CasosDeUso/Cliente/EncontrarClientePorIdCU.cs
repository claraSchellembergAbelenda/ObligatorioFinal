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
    public class EncontrarClientePorIdCU : IFindClienteByIDCU
    {
        public IRepositorioCliente _repositorioCliente;
        public EncontrarClientePorIdCU(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }
        public ClienteDTO EncontrarPorIdCliente(int idCliente)
        {
            ClienteDTO aux = ClienteDtoMapper.ToDto(_repositorioCliente.FindByID(idCliente));
            return aux;
        }
    }
}
