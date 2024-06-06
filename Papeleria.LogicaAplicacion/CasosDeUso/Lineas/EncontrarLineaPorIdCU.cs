using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Lineas
{
    public class EncontrarLineaPorIdCU : IEncontrarLineaPorIdCU
    {
        private IRepositorioLinea _repositorioLinea;
        public EncontrarLineaPorIdCU(IRepositorioLinea repositorioLinea)
        {
            _repositorioLinea = repositorioLinea;
        }

        public Linea EncontrarLineaPorId(int id)
        {
            return _repositorioLinea.FindByID(id);
        }
    }
}
