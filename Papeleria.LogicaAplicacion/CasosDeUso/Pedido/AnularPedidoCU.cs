using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class AnularPedidoCU : IAnularPedidoCU
    {
        private IRepositorioPedido _repositorioPedidos;

        public AnularPedidoCU(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }
        public bool AnularPedido(int id)
        {

            _repositorioPedidos.AnularPedido(id);


            return true;

        }
    }
}
