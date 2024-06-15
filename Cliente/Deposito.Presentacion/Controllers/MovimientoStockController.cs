using Deposito.Presentacion.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Text;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimientoStockModel movimiento)
        {
            try
            {


                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, new Uri("https://localhost:44388/api/MovimientoStock"));
                string json = JsonConvert.SerializeObject(movimiento);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var m = JsonConvert.DeserializeObject<MovimientoStockModel>(objetoComoTexto);
                    ViewBag.SuccessMessage = "MovimientoStock creado con éxito";
                    return View(m);

                }
                else
                {
                    ViewBag.ErrorMessage = $"Error en la respuesta: {respuesta.Result.StatusCode} - {respuesta.Result.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {

                return View();
            }

            return View(movimiento); ;



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
