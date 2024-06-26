﻿using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesAccesoDatos
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario FindByEmail(string email);
        IEnumerable<Usuario> UsuariosOrdenadosNombre();
    }
}
