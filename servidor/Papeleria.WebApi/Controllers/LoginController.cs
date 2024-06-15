using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.CasosDeUso;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;

namespace Papeleria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IEncontrarUsuarioPorEmailCU _findUserByMailCU;

        public LoginController(IEncontrarUsuarioPorEmailCU findUserByMailCU)
        {
            _findUserByMailCU = findUserByMailCU;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]

        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                ManejadorJWT handler = new ManejadorJWT(_findUserByMailCU);
                var usr = handler.ObtenerUsuario(usuarioDTO.email);
                if(usr==null || usr.password!= usuarioDTO.password)
                {
                    return Unauthorized("Credenciales invalidas. Por favor reintente");
                }
                var token = ManejadorJWT.GenerarToken(usr);
                return Ok(new
                {
                    Token = token,
                    Usuario = usr
                });
            }
            catch(Exception ex)
            {
                return Unauthorized(new
                {
                    Mensaje="se produjo un error, por favor intente de nuevo"
                });
            }
        }


    }
}
