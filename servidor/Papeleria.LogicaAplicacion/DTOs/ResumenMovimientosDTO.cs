﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ResumenMovimientosDTO
    {
        public int Año { get; set; }
        public int TotalCantidadesMovidas { get; set; }
        public List<MovimientosTipoAño> movimientos { get; set; }
    }
}
