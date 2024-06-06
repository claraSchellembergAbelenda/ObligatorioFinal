using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.PedidoExpress
{
    public class PedidoExpressNoValidoException : Exception
    {
        public PedidoExpressNoValidoException()
        {
        }

        public PedidoExpressNoValidoException(string? message) : base(message)
        {
        }

        public PedidoExpressNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PedidoExpressNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
