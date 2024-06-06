using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesAccesoDatos
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> GetPedidosPendientesPorFecha(DateTime fecha);
        public bool AnularPedido(int id);
        public List<Pedido> GetPedidosAnuladosDesc();
    }
}
