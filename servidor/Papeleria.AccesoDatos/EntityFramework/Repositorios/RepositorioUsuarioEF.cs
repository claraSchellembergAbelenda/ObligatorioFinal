using Papeleria.AccesoDatos.EntityFramework;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Microsoft.EntityFrameworkCore;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private PapeleriaContext _context;
        public RepositorioUsuarioEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Usuario aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Usuarios.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (UsuarioNoValidoException ex)
            {
                throw ex; 
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios;
        }

        public Usuario FindByEmail(string mail)
        {
                return _context.Usuarios.Where(usuario => usuario.email == mail).FirstOrDefault();
        }

        public Usuario FindByID(int id)
        {
            return _context.Usuarios.Where(usuario => usuario.id == id).AsNoTracking().FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Usuario aRemover = _context.Usuarios.Where(usuario => usuario.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.Usuarios.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (UsuarioNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(Usuario aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Usuarios.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (UsuarioNoValidoException ex)
            {
                throw ex;
            }
        }

        #region ____________________Ordenados_______________
        public IEnumerable<Usuario> UsuariosOrdenadosNombre()
        {
            return this._context.Usuarios.OrderBy(usuario => usuario.nombreCompleto.apellido);
        }
        #endregion
    }
}
