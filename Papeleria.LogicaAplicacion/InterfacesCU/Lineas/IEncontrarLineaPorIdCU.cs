using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Lineas
{
    public interface IEncontrarLineaPorIdCU
    {
        public Linea EncontrarLineaPorId(int id);
    }
}
