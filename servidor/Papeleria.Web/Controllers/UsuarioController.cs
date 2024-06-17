using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using System.Reflection.Metadata;

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        #region ___________CASOS DE USO_____________________
        //el controller no debe tener acceso al repositorio
        //hay que suplantarlo por los casos de uso
        private IGetUsuariosAscendenteCU _ordenarAscendente;
        private ICrearUsuarioCU _crearUsuarioCU;
        private IDeleteUsuarioCU _deleteUsuarioCU;
        private IRecibeIdDevuelveUsuarioCU _recibeIdDevuelveUsuarioCU;
        private IUpdateUsuarioCU _updateUsuarioCU;
        private ILoginUsuarioCU _loginUsuarioCU;
        private IDetailsUsuarioCU _detailsUsuarioCU;
        private IEncontrarUsuarioPorEmailCU _encontrarUsuarioPorEmail;

        

        public UsuarioController(IGetUsuariosAscendenteCU ordenarAscendenteCU, 
            ICrearUsuarioCU crearUsuarioCU, IDeleteUsuarioCU deleteUsuarioCU, 
            IRecibeIdDevuelveUsuarioCU recibeIdDevuelveUsuarioCU, IUpdateUsuarioCU updateUsuarioCU, 
            ILoginUsuarioCU loginUsuarioCU, IDetailsUsuarioCU detailsUsuarioCU,
            IEncontrarUsuarioPorEmailCU encontrarUsuarioPorEmailCU)
        {
            this._ordenarAscendente = ordenarAscendenteCU;
            this._crearUsuarioCU = crearUsuarioCU;
            this._deleteUsuarioCU = deleteUsuarioCU;
            this._recibeIdDevuelveUsuarioCU = recibeIdDevuelveUsuarioCU;
            this._updateUsuarioCU = updateUsuarioCU;
            this._loginUsuarioCU = loginUsuarioCU;
            this._detailsUsuarioCU = detailsUsuarioCU;
            this._encontrarUsuarioPorEmail = encontrarUsuarioPorEmailCU;


        }
        #endregion

        #region LOGIN Y LOGOUT
        public ActionResult Login() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contrasenia)
        {
            try
            {
                UsuarioDTO u = _loginUsuarioCU.LoginUsuario(correo, contrasenia);

                HttpContext.Session.SetInt32("LogueadoId", u.Id);
                HttpContext.Session.SetString("LogueadoCorreo", u.email);

                return RedirectToAction("Index", "Home");
            }
            
            catch
            {
                Exception ex;
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            try
            {
                
                HttpContext.Session.SetString("LogueadoCorreo", "");

                return RedirectToAction("Index", "Home");
            }

            catch
            {
                Exception ex;
                return RedirectToAction("Index", "Home");
            }
        }


        #endregion 


        #region INDEX

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(this._ordenarAscendente.GetUsuariosOrdenados());
        }
        #endregion


        #region DETAILS
        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(this._detailsUsuarioCU.DetailsUsuario(id));
            }catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));

            }
        }

        #endregion


        #region CREATE
        // GET: UsuarioController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            UsuarioDTO usuario = _encontrarUsuarioPorEmail.EncontrarUsuarioPorEmail(HttpContext.Session.GetString("LogueadoCorreo"));
            if (usuario.esAdmin == true)
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new {mensaje = "solo los administradores pueden crear usuarios"});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuarioDTO)
        {
            try
            {
                _crearUsuarioCU.CrearUsuario(usuarioDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioNoValidoException ex)
            {
                return RedirectToAction("Index", new {mensaje=ex.Message});
            }
        }



        #endregion


        #region DELETE
        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id, string mensaje)
        {
            ViewBag.mensaje = mensaje;
            UsuarioDTO usuario = _encontrarUsuarioPorEmail.EncontrarUsuarioPorEmail(HttpContext.Session.GetString("LogueadoCorreo"));
            if (usuario.esAdmin == true)
            {
                return View(_recibeIdDevuelveUsuarioCU.RecibeIdDevuelveUsuario(id));
            }
            return RedirectToAction("Index", "Home", new { mensaje = "solo los administradores pueden eliminar usuarios" });
            
        }
        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioDTO user)
        {
            try
            {
                this._deleteUsuarioCU.DeleteUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", new {mensaje=ex.Message});
            }
        }
        #endregion


        #region EDIT
        public ActionResult Edit(int id, string mensaje)
        {
            ViewBag.mensaje = mensaje;
            UsuarioDTO usuario = _encontrarUsuarioPorEmail.EncontrarUsuarioPorEmail(HttpContext.Session.GetString("LogueadoCorreo"));
            if (usuario.esAdmin == true)
            {
                return View(_recibeIdDevuelveUsuarioCU.RecibeIdDevuelveUsuario(id));
            }
            return RedirectToAction("Index", "Home", new { mensaje = "solo los administradores pueden modificar usuarios" });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UsuarioDTO aEditar, string nombre, string apellido, string passwordAEditar, string aValidar)
        {
            try
            {
                var u = new NombreCompleto(nombre, apellido);
                aEditar.nombre=u.nombre;
                aEditar.apellido=u.apellido;
                _updateUsuarioCU.UpdateUsuario(aEditar, passwordAEditar, aValidar);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioNoValidoException ex)
            {
                return RedirectToAction("Index", new {mensaje=ex.Message});
            }
            catch(Exception ex)
            {
                if(ex.InnerException != null)
                {
                    return RedirectToAction("Index", new {mensaje = ex.InnerException.Message});
                }
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
        }


        #endregion


    }
}
