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
    public class FindByIdArticuloCU: IFindByIDArticuloCU
    {
        public IRepositorioArticulo _repositorioArticulo;
        public FindByIdArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public ArticuloDTO EncontrarPorIdArticulo(int idArticulo)
        {
           ArticuloDTO aux= ArticuloDtoMapper.ToDto(_repositorioArticulo.FindByID(idArticulo));
            return aux;
            
        }
    }
}
