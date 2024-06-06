using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Lineas
{
    public class CalcularPrecioLineaCU : ICalcularPrecioLineaCU
    {
        private PedidoDTO PedidoDTO;
        public double CalcularPrecioLinea( LineaDTO l)
        {
            try
            {
                Linea linea = LineaDtoMapper.FromDto(l);
                linea.EsValido();
                //PedidoDTO._lineas.Add(l);
                return linea.CalcularPrecio();
            }
            catch(LineaNoValidaException ex)
            {
                throw new LineaNoValidaException(ex.Message);
            }
            
        }
    }
}
