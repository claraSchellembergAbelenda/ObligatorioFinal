﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock;
using Papeleria.LogicaAplicacion.CasosDeUso.Usuario;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;
using System.Linq;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/MovimientoStock")]
    //[Authorize]
    public class MovimientoStockController : Controller
    {
        // GET: MovimientoStockController
        private IGetPorTipoMovimientoYArticuloCU _getMovimientosPorTipo;
        private IGetArticuloPorFechaMovimiento _getArticuloPorFechaMovimiento;
        private IGetResumeByYearAndTypeUC _getResumeByYearAndTypeUC;
        private IExisteTipoCU _existeTipoMovimientoCU;

        private IFindTipoMovimientoCU _findTipoMovimientoCU;
        private IFindByIDArticuloCU _findArticuloByIdCU;
        private IEncontrarUsuarioPorIdCU _encontrarUsuarioPorIdCU;
        private ICrearMovimientoStockCU _crearMovimientoStockCU;
        private IFindTipoMovimientoByNameCU _findTipoMovimientoByNameCU;
        private IGetAllMovimientosCU _getAllMovimientosCU;
        private IEncontrarUsuarioPorEmailCU _encontrarUsuarioPorEmail;


        public MovimientoStockController(IGetPorTipoMovimientoYArticuloCU getMovimientos, 
            IGetArticuloPorFechaMovimiento getArticuloPorFechaMovimiento, 
            IGetResumeByYearAndTypeUC getResumeByYearAndTypeUC, IExisteTipoCU existeTipoMovimientoCU,
            IFindByIDArticuloCU findByIDArticuloCU,  ICrearMovimientoStockCU crearMovimientoStockCU, IFindTipoMovimientoCU findTipoMovimientoCU,
            IFindTipoMovimientoByNameCU findTipoMovimientoByNameCU, IGetAllMovimientosCU getAllMovimientosCU, IEncontrarUsuarioPorIdCU encontrarUsuarioPorIdCU,
            IEncontrarUsuarioPorEmailCU encontrarUsuarioPorEmailCU)
        {
            _getMovimientosPorTipo = getMovimientos;
            _getArticuloPorFechaMovimiento = getArticuloPorFechaMovimiento;
            _getResumeByYearAndTypeUC = getResumeByYearAndTypeUC;
            _existeTipoMovimientoCU = existeTipoMovimientoCU;
            _findArticuloByIdCU = findByIDArticuloCU;
            _crearMovimientoStockCU = crearMovimientoStockCU;
            _findTipoMovimientoByNameCU = findTipoMovimientoByNameCU;
            _getAllMovimientosCU = getAllMovimientosCU;
            _findTipoMovimientoCU = findTipoMovimientoCU;
            _encontrarUsuarioPorIdCU = encontrarUsuarioPorIdCU;
            _encontrarUsuarioPorEmail = encontrarUsuarioPorEmailCU;


        }

        [HttpGet("Page/{pageNumber}")]
        [HttpGet("ObtenerMovimientosPorArticuloYTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult ObtenerMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento, int numeroDePagina, int tamañoPagina)
        {
            if (numeroDePagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Corrija los settings: numero de pagina y tamaño debe ser positivo");
            }
            try
            {
                TipoMovimientoDTO tipo = _findTipoMovimientoByNameCU.FindTipoMovimientoByName(tipoMovimiento);
                if (tipo!=null)
                {
                    ArticuloDTO art =_findArticuloByIdCU.EncontrarPorIdArticulo(idArticulo);
                    if (art != null)
                    {
                        var movimientos = _getMovimientosPorTipo.GetPorTipoMovimientoYArticulo(idArticulo, tipoMovimiento, numeroDePagina);
                        if (!movimientos.Any())
                        {
                            return NoContent();
                        }
                        return Ok(movimientos);
                    }
                    else
                    {
                        return BadRequest( new { Message = "Id de articulo invalido, por favor trate de vuelta"
                        });
                    }
                }
                else
                {
                    return BadRequest( new
                    {
                        Message = "Tipo de movimiento no encontrado, por favor trate de vuelta"
                    });
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        
        [HttpGet("Filtrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

       
        public ActionResult GetArticulosPorFecha(string fechaInicio, string fechaFin, int numeroDePagina)
        {
            if (numeroDePagina < 1)
            {
                return BadRequest("Pagina debe ser cero o mas.");
            }
            try
            {
                DateTime inicio, fin;

                inicio =DateTime.ParseExact(fechaInicio, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                fin = DateTime.ParseExact(fechaFin, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);


                var articulos = _getArticuloPorFechaMovimiento.GetArticuloPorFechas(inicio, fin, numeroDePagina);

                if (!articulos.Any())
                {
                    return NoContent();
                }
                return Ok(articulos);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMovementsByYearAndType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetMovementsByYearAndType()
        {
            try { 
            
                return Ok(_getResumeByYearAndTypeUC.ObtenerResumenMovimiento());

            }
            catch (MovimientoStockNoValidoException mv)
            {
                return BadRequest(mv.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovimientoStockDTO> Create([FromBody] MovimientoStockDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dto vacío");
            }
            
            try
            {
                dto.articuloMovido = _findArticuloByIdCU.EncontrarPorIdArticulo(dto.articuloMovidoId);
                dto.tipoMovimiento = _findTipoMovimientoCU.FindTipoMovimiento(dto.tipoMovimientoId);
                
                _crearMovimientoStockCU.CrearMovimiento(dto);
                return Created("api/MovimientoStock", dto);
            }
            catch (MovimientoStockNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inesperado con la base de datos");
            }
        }

        
    }
}
