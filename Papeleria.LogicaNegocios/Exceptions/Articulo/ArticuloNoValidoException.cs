using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.Articulo
{
    public class ArticuloNoValidoException : Exception
    {
        public ArticuloNoValidoException()
        {
        }

        public ArticuloNoValidoException(string? message) : base(message)
        {
        }

        public ArticuloNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArticuloNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
