using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.InterfacesUC;

namespace Papeleria.LogicaAplicacion.CasosDeUso
{
    public class ObtenerUsuariosUC : IListarUsuariosUC
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuariosUC(IRepositorioUsuario _repositorioUsuario)
        {
            this._repositorioUsuario = _repositorioUsuario;
        }
        

        IEnumerable<LogicaNegocio.Entidades.Usuario> IListarUsuariosUC.DevolverUsuarios()
        {
            return _repositorioUsuario.FindAll();
        }
    }
}
