using Deposito.Presentacion.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Deposito.Presentacion.Controllers
{
    public class MovimientoStockController : Controller
    {
        private HttpClient cliente;
        private string baseURL;
        public MovimientoStockController() 
        {

            cliente = new HttpClient();
            baseURL = "https://localhost:7039/api/MovimientoStock/";
        }

        public ActionResult GetMovimientosPorFechas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMovimientosPorFechas(DateTime f1, DateTime f2)
        {
            try
            {
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(baseURL + "/Filtrar/" + f1 +"/"+ f2));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var movimientos = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockModel>>(objetoComoTexto);
                    return View(movimientos);
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Errors", new { text = "404notfound" });
            }
            return View();
        }
    }
}
