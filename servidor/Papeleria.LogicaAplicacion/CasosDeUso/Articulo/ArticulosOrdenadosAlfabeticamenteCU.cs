using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ArticulosOrdenadosAlfabeticamenteCU : IArticulosOrdenadosAlfabeticamenteCU
    {
        private IRepositorioArticulo _repositorioArticulo;

        public ArticulosOrdenadosAlfabeticamenteCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public List<ArticuloDTO> GetArticulosOrdenados()
        {
            var articulos = _repositorioArticulo.FindAll().OrderBy(a => a.nombre);
            return articulos.Select(a=>ArticuloDtoMapper.ToDto(a)).ToList();
        }

    }
}
