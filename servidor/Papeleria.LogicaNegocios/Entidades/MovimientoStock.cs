using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Exceptions.MovimientoStock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocios.Entidades
{
    public class MovimientoStock : IValidable <MovimientoStock>
    {
        //Los movimientos de stock deberán tener un Id autonumérico, fecha y hora del movimiento,
        //artículo que se “mueve”, tipo de movimiento de stock, usuario que lo llevó a cabo, y la cantidad de
        //unidades que se mueven.

        public int id { get;set; }
        public DateTime fechaYHora { get;set; }

        [ForeignKey(nameof(articuloMovido))] public int articuloMovidoId { get; set; }
        public Articulo articuloMovido { get;set; }

        [ForeignKey(nameof(tipoMovimiento))] public int tipoMovimientoId { get; set; }
        public TipoMovimiento tipoMovimiento { get;set; }
        [ForeignKey(nameof(usuario))] public int usuarioId { get; set; }
        public Usuario usuario { get;set; }
        public int cantUnidadesMovidas { get; set; }

        public MovimientoStock() { }

        public MovimientoStock(int id, DateTime fechaYHora, Articulo articuloMovido, TipoMovimiento tipoMovimiento, Usuario usuario, int cantUnidadesMovidas)
        {
            this.id = id;
            this.fechaYHora = DateTime.Now;
            this.articuloMovido = articuloMovido;
            this.articuloMovidoId = articuloMovido.id;
            this.tipoMovimiento = tipoMovimiento;
            this.tipoMovimientoId = tipoMovimiento.id;
            this.usuario = usuario;
            this.usuarioId = usuario.id;
            this.cantUnidadesMovidas = cantUnidadesMovidas;
        }

        public void EsValido()
        {
            ValidarStock();
            ValidarArticulo();
        }
        public void ValidarStock()
        {
            if (cantUnidadesMovidas <= 0)
            {
                throw new MovimientoStockNoValidoException("las unidades a mover deben ser positivas");
            }
           
        }
        public void ValidarArticulo()
        {
            //▪ El artículo será uno de los existentes.
            if (this.articuloMovido == null)
            {
                throw new MovimientoStockNoValidoException("el articulo que esta tratando de mover no puede ser null");
            }
        }


        //▪ El usuario exista, y se haya autenticado con rol encargado.
        public void ValidarUsuario()
        {
            if (usuario == null)//esto no valida que exista, aca hay que checkear con la base de datos
            {
                throw new MovimientoStockNoValidoException("el usuario debe estar");
            }
            if (usuario.esEncargado==false) 
            {

                throw new MovimientoStockNoValidoException("el usuario debe se encargado para poder iniciar sesion");
            }
        }

        //▪ Solo se manejan ingresos y egresos.
        //public void ValidarTipoMovimiento()
        //{
        //    if(this.tipoMovimiento.nombreMovimiento.ToUpper() != "venta".ToUpper()
        //        && this.tipoMovimiento.nombreMovimiento.ToUpper() != "devolucion".ToUpper())
        //    {
        //        throw new MovimientoStockNoValidoException("no se puede ingresar un movimiento que no sea de ingresos o egresos");
        //    }
        //}

        //El tipo de movimiento de stock sea uno de los existentes.



    }
}
