using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.PedidoComun
{
    public class PedidoComunNoValidoException : Exception
    {
        public PedidoComunNoValidoException()
        {
        }

        public PedidoComunNoValidoException(string? message) : base(message)
        {
        }

        public PedidoComunNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PedidoComunNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
