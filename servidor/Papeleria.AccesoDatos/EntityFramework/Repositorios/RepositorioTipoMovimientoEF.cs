using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioTipoMovimientoEF : IRepositorioTipoMovimiento
    {
        private PapeleriaContext _context;
        public RepositorioTipoMovimientoEF()
        {
            this._context = new PapeleriaContext();
        }
        
        public bool Add(TipoMovimiento aAgregar)
        {
            try
            {
                this._context.TiposDeMovimientos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            //catch (TipoNotValidException e)
            //{
            //    throw e;
            //}
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            return _context.TiposDeMovimientos;
        }

        public TipoMovimiento FindByID(int id)
        {
            return _context.TiposDeMovimientos.Where(usuario => usuario.id == id).AsNoTracking().FirstOrDefault();
        }
        

        public bool Remove(int id)
        {
            try
            {
                TipoMovimiento aRemover = _context.TiposDeMovimientos.Where(t => t.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.TiposDeMovimientos.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            //catch (TipoDeMovimientoNoValidoException ex)
            //{
            //    throw ex;
            //}
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(TipoMovimiento aModificar)
        {
            try
            {
                //aModificar.EsValido();
                _context.TiposDeMovimientos.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            //catch (TipoDeMovimientoNoValidoException ex)
            //{
            //    throw ex;
            //}
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
