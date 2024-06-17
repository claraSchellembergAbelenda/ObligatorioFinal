using Deposito.Presentacion.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Net;
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
                else if (respuesta.Result.StatusCode == HttpStatusCode.BadRequest)
                {
                    var mensajeError = respuesta.Result.Content.ReadAsStringAsync().Result;
                    ViewBag.ErrorMessage = mensajeError; 
                }
                else
                {
                    ViewBag.ErrorMessage = $"Error en la respuesta: {respuesta.Result.StatusCode} - {respuesta.Result.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error al procesar la solicitud.";
            }

            return View(movimiento);
        }
        
        //public ActionResult Create(MovimientoStockModel movimiento)
        //{
        //    try
        //    {


        //        HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, new Uri("https://localhost:44388/api/MovimientoStock"));
        //        string json = JsonConvert.SerializeObject(movimiento);
        //        HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
        //        solicitud.Content = contenido;
        //        Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
        //        respuesta.Wait();

        //        if (respuesta.Result.IsSuccessStatusCode)
        //        {
        //            var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
        //            var m = JsonConvert.DeserializeObject<MovimientoStockModel>(objetoComoTexto);
        //            ViewBag.SuccessMessage = "MovimientoStock creado con éxito";
        //            return View(m);

        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = $"Error en la respuesta: {respuesta.Result.StatusCode} - {respuesta.Result.ReasonPhrase}";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return View();
        //    }

        //    return View(movimiento); ;



        //}

        public ActionResult GetMovimientosPorFechas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMovimientosPorFechas(DateTime f1, DateTime f2)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                if (string.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Index", "Home", new { message = "Usted no esta autenticado, por favor inicie sesion" });
                }
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    token
                    );
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

        #region GetMovimientosPorIdYTipo

        public ActionResult GetMovimientosPorId(string message)
        {
            ViewBag.message = message;
            return View();
        }

        [HttpPost]

        public ActionResult GetMovimientosPorId(int idArticulo, string tipoMovimiento)
        {
            try
            {
                if (idArticulo <= 0 || string.IsNullOrEmpty(tipoMovimiento))
                {
                    return View(new
                    { message = "Los datos ingresados son incorrectos, por favor recuerde que el id debe ser positivo y el tipoMovimiento no puede ser vacio" });
                }

                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get,
                    new Uri(baseURL + "ObtenerMovimientosPorArticuloYTipo?idArticulo=" + idArticulo + "&tipoMovimiento=" + tipoMovimiento));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var movimientos = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockModel>>(objetoComoTexto);
                    if (!movimientos.Any())
                    {
                        return View(new { message = "No hay articulos que hayan pasado por ese movimiento" });
                    }
                    return View(movimientos);
                }
                return View(new { message = "Tuvimos un problema, por favor trate de vuelta" });
            }
            catch (Exception e)
            {
                return RedirectToAction("GetMovimientosPorId", new
                { message = e.Message });
            }

        }

        #endregion

        #region GetResumenMovimientoPorAño

        public ActionResult GetResumenMovimientoPorAñoYTipo()
        {
            try
            {
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get,
                   new Uri(baseURL + "GetMovementsByYearAndType"));
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();
                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var ResumenMovimientos = JsonConvert.DeserializeObject<IEnumerable<ResumenMovimientosModel>>(objetoComoTexto);

                    return View(ResumenMovimientos);
                }

                return RedirectToAction("GetResumenMovimientoPorAñoYTipo", new { mensaje = "Algo sucedio mal, por favor trate de vuelta" });
            }
            catch (Exception e)
            {
                return RedirectToAction("GetResumenMovimientoPorAñoYTipo", new { mensaje = e.Message });
            }
        }

        #endregion
    }
}
