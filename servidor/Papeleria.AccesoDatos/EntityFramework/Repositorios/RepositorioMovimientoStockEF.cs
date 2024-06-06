using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public class RepositorioMovimientoStockEF : IRepositorioMovimientoStock
    {
        private PapeleriaContext _context;
        public RepositorioMovimientoStockEF()
        {
            this._context = new PapeleriaContext();
        }
        public IEnumerable<MovimientoStock> GetPorTipoYArticulo(int idArticulo, string tipoMovimiento)
        {
            return _context.MovimientosStock
                            .Where(m => m.articuloMovidoId == idArticulo && m.tipoMovimiento.Equals( tipoMovimiento))
                            .orderByDescending(m => m.fechaYHora)

                            .groupBy(m.cantUniddadesMovidas)
                            .include(m.tipoMovimiento)
}
        public IEnumerable<Articulo> GetArticuloPorFechaMovimiento(DateTime f1, DateTime f2)
        {
            return _context.MovimientosStock.Where(mv => mv.fechaYHora >= f1 && mv.fechaYHora <= f2)
                .Include(mv => mv.articuloMovido)
                .Select(a => a.articuloMovido);
        }

        //c.Obtener la información de resumen de las cantidades movidas agrupadas por año, y
        //dentro de año por tipo de movimiento.

        //public IEnumerable<MovimientoStock> GetResumenAgrupadoPorTipoYAño()
        //{
        //    return _context.MovimientosStock.GroupBy(mv=> mv.fechaYHora.Year).
        //}

        public bool Add(MovimientoStock aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientoStock> FindAll()
        {
            throw new NotImplementedException();
        }

        public MovimientoStock FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(MovimientoStock aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
