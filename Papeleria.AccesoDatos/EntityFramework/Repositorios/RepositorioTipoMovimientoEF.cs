using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
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
            throw new NotImplementedException();
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public TipoMovimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoMovimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
