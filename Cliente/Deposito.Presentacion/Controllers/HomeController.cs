using Deposito.Presentacion.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Deposito.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient cliente;
        private string baseURL;
        public HomeController()
        {
            cliente = new HttpClient();
            baseURL = "https://localhost:44388/api/Login/Login";
        }
        public IActionResult Login(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string password) 
        {
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, new Uri(baseURL));
            UsuarioModel model = new UsuarioModel();
            model.email= email;
            model.password = password;
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            solicitud.Content = content;
            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();
            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<TokenModel>(objetoComoTexto);
                HttpContext.Session.SetString("email",email);
                HttpContext.Session.SetString("token", user.Token);

                return RedirectToAction("Index", "Home", new { message = "Login realizado correctamente"});
            }
            return RedirectToAction("Login", "Home", new { message = "email o contraseña incorrecta, por favor trate de vuelta" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("token", "");
            return RedirectToAction("Login");
        }
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
