﻿using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.MovimientoStock
{
    public interface IGetArticuloPorFechaMovimiento
    {
        public IEnumerable<ArticuloDTO> GetArticuloPorFechas(DateTime f1, DateTime f2, int numeroDePagina);
    }
}
