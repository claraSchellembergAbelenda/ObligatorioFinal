using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;

namespace Papeleria.WebApi.Controllers
{
    public class MovimientoStockController : Controller
    {
        // GET: MovimientoStockController
        private IGetPorTipoMovimientoYArticuloCU _getMovimientos;
        private IGetArticuloPorFechaMovimiento _getArticuloPorFechaMovimiento;
        public MovimientoStockController(IGetPorTipoMovimientoYArticuloCU getMovimientos, IGetArticuloPorFechaMovimiento getArticuloPorFechaMovimiento)
        {
            _getMovimientos = getMovimientos;
            _getArticuloPorFechaMovimiento = getArticuloPorFechaMovimiento;
        }


        [HttpGet("Filtrar/{fechaInicio}/{fechaFin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult GetArticulosPorFecha( DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return View(_getArticuloPorFechaMovimiento.GetArticuloPorFechas(fechaInicio, fechaFin));

            }
            catch(Exception ex)
            {
                return View(BadRequest());
            }
        }



        public ActionResult Index()
        {
            return View();
        }

        // GET: MovimientoStockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimientoStockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimientoStockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimientoStockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimientoStockController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimientoStockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimientoStockController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
