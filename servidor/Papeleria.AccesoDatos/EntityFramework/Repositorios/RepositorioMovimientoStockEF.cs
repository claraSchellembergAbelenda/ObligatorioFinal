using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocios.Entidades;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;
using Papeleria.LogicaNegocios.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        private PapeleriaContext _context;
        public RepositorioMovimientoStockEF()
        {
            this._context = new PapeleriaContext();
        }

        public IEnumerable<MovimientoStock> GetPorTipoYArticulo(int idArticulo, string tipo, int numeroDePagina, int tamañoPagina)
        {
            return _context.MovimientosStock
                            .Where(ms => ms.articuloMovidoId == idArticulo && ms.tipoMovimiento.nombreMovimiento.Equals(tipo))
                            .OrderByDescending(ms => ms.fechaYHora)
                            .ThenBy(ms => ms.cantUnidadesMovidas)
                            .Include(ms => ms.tipoMovimiento)
                            .Skip((numeroDePagina - 1) * tamañoPagina)
                            .Take(tamañoPagina)
                            .ToList();


        }

        public IEnumerable<Articulo> GetArticuloPorFechaMovimiento(DateTime f1, DateTime f2, int numeroDePagina, int tamañoPagina)
        {
            return _context.MovimientosStock.Where(mv => EF.Functions.DateDiffDay(f1, mv.fechaYHora) >= 0 && EF.Functions.DateDiffDay(mv.fechaYHora, f2) >= 0)
                .Include(mv => mv.articuloMovido)
                .Select(a => a.articuloMovido)
                .Distinct() 
                .Skip((numeroDePagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToList();
        }



        //c.Obtener la información de resumen de las cantidades movidas agrupadas por año, y
        //dentro de año por tipo de movimiento.


        public bool Add(MovimientoStock aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                this._context.Entry(aAgregar.articuloMovido).State = EntityState.Unchanged;
                this._context.Entry(aAgregar.usuario).State = EntityState.Unchanged;
                this._context.Entry(aAgregar.tipoMovimiento).State = EntityState.Unchanged;
                _context.MovimientosStock.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (MovimientoStockNoValidoException ex)
            {
                throw new MovimientoStockNoValidoException(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MovimientoStock> FindAll()
        {
            return _context.MovimientosStock.Include(mv => mv.tipoMovimiento);
        }

        public MovimientoStock FindByID(int id)
        {
            return _context.MovimientosStock.Where(m => m.id == id).FirstOrDefault();
        }

        
        public bool Update(MovimientoStock aModificar)
        {
            throw new NotImplementedException();
        }
        public bool ExisteTipo(string tipo) {

            if(_context.MovimientosStock.Any(m => m.tipoMovimiento.nombreMovimiento == tipo))
            {
                return true;
            }

            return false;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
