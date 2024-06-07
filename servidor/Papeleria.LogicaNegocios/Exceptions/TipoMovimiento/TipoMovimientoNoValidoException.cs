using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocios.Exceptions.TipoMovimiento
{
    public class TipoMovimientoNoValidoException : Exception
    {
        public TipoMovimientoNoValidoException()
        {
        }

        public TipoMovimientoNoValidoException(string? message) : base(message)
        {
        }

        public TipoMovimientoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TipoMovimientoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
