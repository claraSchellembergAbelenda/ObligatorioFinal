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
    public class CrearArticuloCU : ICrearArticuloCU
    {
        private IRepositorioArticulo _repositorioArticulo;
        
        public CrearArticuloCU (IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public bool CrearArticulo(ArticuloDTO dtoACrear)
        {
            if (this._repositorioArticulo.Add(ArticuloDtoMapper.FromDto(dtoACrear)))
            {
                return true;
            }
            return false;
        }
    }
}
