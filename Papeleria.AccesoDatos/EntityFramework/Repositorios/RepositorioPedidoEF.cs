using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        private PapeleriaContext _context;
        public RepositorioPedidoEF()
        {
            _context = new PapeleriaContext();
        }

        

        public bool Add(Pedido aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                this._context.Entry(aAgregar.cliente).State = EntityState.Unchanged;
                //aAgregar.clienteId = aAgregar.cliente.id;
                //aAgregar.cliente = null;
                foreach(Linea l in aAgregar._lineas)
                {
                    this._context.Entry(l.articulo).State = EntityState.Unchanged;
                }
                _context.Pedidos.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw new PedidoComunNoValidoException(ex.Message);
            }
            catch(Exception ex)
            {
                if(ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                throw new Exception( ex.Message);
            }
        }

        

        public IEnumerable<Pedido> FindAll()
        {
            return _context.Pedidos;
        }

        public Pedido FindByID(int id)
        {
                return _context.Pedidos.Where(pedido => pedido.id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Pedido aRemover = _context.Pedidos.Where(p => p.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.Pedidos.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(Pedido aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Pedidos.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Pedido> GetPedidosPendientesPorFecha(DateTime fecha)
        {
            return this._context.Pedidos
               .Where(p => p.estadoPedido == EstadoPedido.Pendiente && p.fechaPedido.Date == fecha.Date)
               .ToList();
        }

        public bool AnularPedido(int id)
        {
            Pedido pedidoAnular = FindByID(id);
            pedidoAnular.estadoPedido = EstadoPedido.Anulado;
            //this._context.Entry(pedidoAnular.cliente).State = EntityState.Unchanged;

            _context.Pedidos.Update(pedidoAnular);

            _context.SaveChanges();
            return true;
        }
        public List<Pedido> GetPedidosAnuladosDesc()
        {
            return this._context.Pedidos
                        .Where(p => p.estadoPedido == EstadoPedido.Anulado)
                        .OrderByDescending(p => p.fechaPedido)
                        .ToList();
        }

    }
}
