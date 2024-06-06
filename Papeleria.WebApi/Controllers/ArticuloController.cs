using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/Articulos")]
    public class ArticuloController : ControllerBase
    {

        private IArticulosOrdenadosAlfabeticamenteCU _artOrdenadosUC;

        public ArticuloController(IArticulosOrdenadosAlfabeticamenteCU artOrdenadosUC)
        {
            _artOrdenadosUC = artOrdenadosUC;
        }

        [HttpGet(Name = "GetArticulosOrdenados")]
        public ActionResult <IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                return Ok(this._artOrdenadosUC.GetArticulosOrdenados().ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
