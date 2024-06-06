using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocios.Entidades
{
    public class Setting
    {
        [Key]
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
