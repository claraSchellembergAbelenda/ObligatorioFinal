using Microsoft.VisualBasic;
using Microsoft.Win32;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Exceptions.TipoMovimiento;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.LogicaNegocios.Entidades
{
    public class TipoMovimiento : IValidable<TipoMovimiento>
    {
        //Los tipos de movimiento constan de un Id, un nombre único, (por ejemplo “Venta”, “Devolución”,
        //“Compra”, etc.).
        //En algunos casos el tipo de movimiento corresponde a una reducción del stock, y en otros casos a
        //un aumento.
        public int id {  get; set; }
        public string nombreMovimiento { get; set; } //unique!!
        public int esPositivo { get; set; }
        public TipoMovimiento() { }
        public TipoMovimiento(int id, string nombreMovimiento, int esPositivo)
        {
            this.id = id;
            this.nombreMovimiento = nombreMovimiento;
            this.esPositivo = esPositivo;
        }

        public void validarSigno()
        {
            if(esPositivo!=1 && esPositivo!=-1)
            {
                throw new TipoMovimientoNoValidoException();
            }
        }
        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}