using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class PedidoDtoMapper
    {
        public static PedidoDTO ToDto(Pedido pedido) 
        {
            return new PedidoDTO(pedido);
        }


        public static PedidoComun ToPedidoComun(PedidoDTO dto)
        {
            try
            {
                List<Linea> _lineas = dto._lineas.Select(lineaDto => new Linea(ArticuloDtoMapper.FromDto(lineaDto.articulo), lineaDto.cantUnidades)).ToList();
                _lineas.ForEach(l => l.EsValido());
                Direccion direccion = new Direccion(dto.cliente.calle, dto.cliente.numeroPuerta, dto.cliente.ciudad);
                NombreCompletoClientes nombreCompletoClientes = new NombreCompletoClientes(dto.cliente.nombre, dto.cliente.apellido);
                Cliente cliente = ClienteDtoMapper.FromDto(dto.cliente);
                //new Cliente(dto.cliente.razonSocial, dto.cliente.rut, direccion, dto.cliente.distancia, nombreCompletoClientes);
                return new PedidoComun(cliente, _lineas, dto.descuento, dto.fechaEntregaDeseada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static PedidoExpress ToPedidoExpress(PedidoDTO dto)
        {
            List<Linea> _lineas = dto._lineas.Select(lineaDto => new Linea(ArticuloDtoMapper.FromDto(lineaDto.articulo), lineaDto.cantUnidades)).ToList();


            Direccion direccion = new Direccion(dto.cliente.calle, dto.cliente.numeroPuerta, dto.cliente.ciudad);
            NombreCompletoClientes nombreCompletoClientes = new NombreCompletoClientes(dto.cliente.nombre, dto.cliente.apellido);
            Cliente cliente = ClienteDtoMapper.FromDto(dto.cliente);
                //new Cliente(dto.cliente.razonSocial, dto.cliente.rut, direccion, dto.cliente.distancia, nombreCompletoClientes);
            return new PedidoExpress(cliente, _lineas, dto.descuento, dto.fechaEntregaDeseada);
        }
    }
}
