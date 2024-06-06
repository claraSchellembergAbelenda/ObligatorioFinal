using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.BusinessLogic.ValueObjects
{
    [Owned]
    public class NombreCompleto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public NombreCompleto() { }
        public NombreCompleto(string nombre, string apellido) { this.nombre = nombre; this.apellido = apellido; }
    }
}
