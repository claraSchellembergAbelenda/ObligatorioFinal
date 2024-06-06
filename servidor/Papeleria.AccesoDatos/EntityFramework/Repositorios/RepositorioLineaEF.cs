using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioLineaEF : IRepositorioLinea
    {
        private PapeleriaContext _context;
        public RepositorioLineaEF()
        {
            _context = new PapeleriaContext();
        }

        public bool Add(Linea aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Lineas.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (LineaNoValidaException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Linea> FindAll()
        {
            return _context.Lineas;
        }

        public Linea FindByID(int id)
        {
                return _context.Lineas.Where(linea => linea.Id == id).FirstOrDefault();
        }
        public List<Linea> FindByPedidoId(int id)
        {
            return _context.Lineas.Where(linea => linea.pedidoId == id).ToList();
        }

        public bool Remove(int id)
        {
            try
            {
                Linea aRemover = _context.Lineas.Where(linea => linea.Id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.Lineas.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (ClienteNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(Linea aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Lineas.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (LineaNoValidaException ex)
            {
                throw ex;
            }
        }
    }
}
