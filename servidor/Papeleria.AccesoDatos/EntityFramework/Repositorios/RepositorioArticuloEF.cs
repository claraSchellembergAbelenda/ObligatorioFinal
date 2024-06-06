using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioArticuloEF : IRepositorioArticulo
    {
        private PapeleriaContext _context;
        public RepositorioArticuloEF()
        {
            _context = new PapeleriaContext();
        }
        #region agregar
        public bool Add(Articulo aAgregar)
        {
            try
            {
               aAgregar.EsValido();
               _context.Articulo.Add(aAgregar);
               _context.SaveChanges();
               return true;
            }
            catch(ArticuloNoValidoException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region findAll y findById
        public IEnumerable<Articulo> FindAll()
        {
            return _context.Articulo;
        }

        public Articulo FindByID(int Id)
        {
                return _context.Articulo.Where(articulo => articulo.id==Id).FirstOrDefault();
        }
        #endregion

        #region remove
        public bool Remove(int id)
        {
            try
            {
                Articulo aRemover = _context.Articulo.Where(art => art.id == id).FirstOrDefault();
                if(aRemover==null) 
                {
                    return false;
                }
                _context.Articulo.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch(ArticuloNoValidoException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region update
        public bool Update(Articulo aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Articulo.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (ArticuloNoValidoException ex)
            {
                throw ex;
            }
        }
        #endregion
        public IEnumerable<Articulo> GetArticulosOrdenadosAlfabeticamente()
        {
            return this._context.Articulo.OrderBy(articulo => articulo.nombre);
        }

    }

}
