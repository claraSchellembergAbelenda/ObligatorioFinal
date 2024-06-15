using Deposito.Presentacion.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deposito.Presentacion.Controllers
{
    public class MovimientoStockController : Controller
    {
        private HttpClient cliente;
        private string baseURL;
        public MovimientoStockController() 
        {

            cliente = new HttpClient();
            baseURL = "https://localhost:44388/api/MovimientoStock/";
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult Create(string message)
        {
            try
            {
                

                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:44388/api/TipoMovimiento"));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var tipos = JsonConvert.DeserializeObject<IEnumerable<TipoMovimientoModel>>(objetoComoTexto);
                    ViewBag.Tipos = tipos;

                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            try
            {


                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:44388/api/Articulos"));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var tipos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(objetoComoTexto);
                    ViewBag.Articulos = tipos;

                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();




        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(MovimientoStockModel MovimientoStock, string playerName)
        {
            try

            {
                PlayerModel player = new PlayerModel { Name = playerName };
                if (tempMovimientoStock == null)
                {
                    tempMovimientoStock = new MovimientoStockModel { Players = new List<PlayerModel>() };
                }
                tempMovimientoStock.Players.Add(player);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }
        */











        public ActionResult GetMovimientosPorFechas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMovimientosPorFechas(DateTime f1, DateTime f2)
        {
            try
            {
                string inicio = f1.ToString("dd-MM-yyyy");
                string fin = f2.ToString("dd-MM-yyyy");
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, new Uri(baseURL + "Filtrar?fechaInicio=" + inicio +"&fechafin="+ fin));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(objetoComoTexto);
                    return View(articulos);
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
