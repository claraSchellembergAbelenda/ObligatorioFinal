using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocios.Exceptions.MovimientoStock
{
    [Serializable]
    //?? preguntarle al profe
    public class MovimientoStockNoValidoException : Exception
    {
        public MovimientoStockNoValidoException()
        {
        }

        public MovimientoStockNoValidoException(string? message) : base(message)
        {
        }

        public MovimientoStockNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoStockNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}