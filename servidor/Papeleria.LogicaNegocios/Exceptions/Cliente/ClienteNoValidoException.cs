using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.Cliente
{
    public class ClienteNoValidoException : Exception
    {
        public ClienteNoValidoException()
        {
        }

        public ClienteNoValidoException(string? message) : base(message)
        {
        }

        public ClienteNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClienteNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
