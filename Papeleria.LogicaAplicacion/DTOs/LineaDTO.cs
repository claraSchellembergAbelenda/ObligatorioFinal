using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class LineaDTO
    {
        public int Id { get; set; }
        [ForeignKey(nameof(articulo))] public int articuloId { get; set; }
        public ArticuloDTO articulo { get; set; }
        public int cantUnidades { get; set; }
        public double precioLinea { get; set; }
        public LineaDTO() { }
        public LineaDTO(ArticuloDTO articulo, int cantUnidades, double precioLinea)
        {
            this.articulo = articulo;
            this.cantUnidades = cantUnidades;
            this.precioLinea = precioLinea;
        }
        public LineaDTO(Linea linea)
        {
            if (linea != null)
            {
                //preguntarle como seria en el caso de ArticuloDTO
                cantUnidades = linea.cantUnidades;
                precioLinea = linea.precioLinea;
                articuloId = linea.articuloId;
                Id = linea.Id;
            }
        }
    }
}
