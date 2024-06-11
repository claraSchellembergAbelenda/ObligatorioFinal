﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.CasosDeUso.MovimientoStock;
using Papeleria.LogicaAplicacion.CasosDeUso.TipoMovimiento;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock;
using Papeleria.LogicaAplicacion.InterfacesCU.TipoMovimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/TipoMovimiento")]
    public class TipoMovimientoController : Controller
    {
        private ICrearTipoMovimientoCU _crearTipoMovimientoCU;
        private IEliminarTipoMovimientoCU _eliminarTipoMovimientoCU;
        private IUpdateTipoMovientoCU _updateTipoMovimientoCU;
        private IGetTiposMovimientoCU _getTiposMovimientoCU;
        private IFindTipoMovimientoCU _findTipoMovimientoCU;
        private IExisteTipoCU _existeTipoCU;
        public TipoMovimientoController(ICrearTipoMovimientoCU crearTipoMovimientoCU, IEliminarTipoMovimientoCU eliminarTipoMovimientoCU, IUpdateTipoMovientoCU updateTipoMovientoCU, IGetTiposMovimientoCU getTiposMovimientoCU, IFindTipoMovimientoCU findTipoMovimientoCU, IExisteTipoCU existeTipoCU)
        {
            _crearTipoMovimientoCU = crearTipoMovimientoCU;
            _eliminarTipoMovimientoCU = eliminarTipoMovimientoCU;
            _updateTipoMovimientoCU = updateTipoMovientoCU;
            _getTiposMovimientoCU = getTiposMovimientoCU;
            _findTipoMovimientoCU = findTipoMovimientoCU;
            _existeTipoCU = existeTipoCU;


        }


        [HttpGet(Name = "GetTiposMovimientos")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> GetTiposMovimieto()
        {
            return Ok(_getTiposMovimientoCU.GetTipoMovimientos());
        }

        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> FindTipoMovimiento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The Id must be a positive number.");
            }
            TipoMovimientoDTO toReturn = _findTipoMovimientoCU.FindTipoMovimiento(id);
            if (toReturn != null)
            { 
                return Ok(toReturn);
            }
            return NoContent();
            

        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Create(TipoMovimientoDTO TipoMovimientoDTO)
        {
            
            try
            {
                
                _crearTipoMovimientoCU.CrearTipoMovimiento(TipoMovimientoDTO);
                return Created("api/TipoMovimiento", TipoMovimientoDTO);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest("Error inesperado con la base de datos");
            }


        }
        [HttpDelete("tipoMovimientoId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Delete(int id)
        {
            
            var aEliminar = _findTipoMovimientoCU.FindTipoMovimiento(id);
            string tipo = aEliminar.nombreMovimiento;

            


            if (_existeTipoCU.ExisteTipo(tipo))
            {
                return BadRequest("No puede eliminar un tipo de movimiento en uso");
            }
            else
            {
                try
                {
                    _eliminarTipoMovimientoCU.EliminarTipoMovimiento(id);
                    return Ok();

                }
                catch (TipoMovimientoNoValidoException ex)
                {
                    return BadRequest(ex.Message);
                }

                catch (Exception ex)
                {
                    return BadRequest("Error inesperado con la base de datos");
                }
            }


        }
        [HttpPut("{tipoMovimientoId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Update([FromBody]TipoMovimientoDTO dto)
        {
            try
            {

                this._updateTipoMovimientoCU.UpdateTipoMoviento(dto);



                return Ok();
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest("Error inesperado con la base de datos");
            }


        }

    }
 }

    

