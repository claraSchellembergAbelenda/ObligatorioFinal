using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.Linea
{
    public class LineaNoValidaException : Exception
    {
        public LineaNoValidaException()
        {
        }

        public LineaNoValidaException(string? message) : base(message)
        {
        }

        public LineaNoValidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LineaNoValidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
