using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class DeleteUsuarioCU : IDeleteUsuarioCU 
    {
        private IRepositorioUsuario _repositorioUsuario;
        public DeleteUsuarioCU(IRepositorioUsuario repositorioUsuario) 
        {
            _repositorioUsuario = repositorioUsuario;
        }
       
        
        public void DeleteUsuario(int id)
        {
            Papeleria.LogicaNegocio.Entidades.Usuario u = _repositorioUsuario.FindByID(id);
            _repositorioUsuario.Remove(u.id);
        }
    }
}
