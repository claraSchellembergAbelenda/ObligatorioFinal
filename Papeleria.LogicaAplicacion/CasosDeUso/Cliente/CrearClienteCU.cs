using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Cliente
{
    public class CrearClienteCU : ICrearClienteCU
    {
        private IRepositorioCliente _repositorioCliente;
        public CrearClienteCU (IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }
        public void CrearCliente(ClienteDTO dtoACrear)
        {
            this._repositorioCliente.Add(ClienteDtoMapper.FromDto(dtoACrear));
        }
    }
}
