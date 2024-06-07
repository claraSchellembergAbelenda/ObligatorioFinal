using Microsoft.VisualBasic;
using Microsoft.Win32;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.LogicaNegocios.Entidades
{
    public class TipoMovimiento : IValidable<TipoMovimiento>
    {
        //Los tipos de movimiento constan de un Id, un nombre único, (por ejemplo “Venta”, “Devolución”,
        //“Compra”, etc.).
        //En algunos casos el tipo de movimiento corresponde a una reducción del stock, y en otros casos a
        //un aumento.
        //Nota: Si el movimiento es un traslado (ej.: cambio de estantería, dentro del depósito, una caja con
        //resmas de papel) no se registra un movimiento de stock.No habrá en este sistema la posibilidad
        //de registrar tipos de movimiento que no impliquen un cambio en el stock.
        public int id {  get; set; }
        public string nombreMovimiento { get; set; }
        public TipoMovimiento() { }
        public TipoMovimiento(int id, string nombreMovimiento)
        {
            this.id = id;
            this.nombreMovimiento = nombreMovimiento;
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}