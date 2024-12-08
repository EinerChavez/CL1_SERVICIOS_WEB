using System.ComponentModel.DataAnnotations.Schema;

namespace PREGUNTA_03_CRUD.Models
{
    [Table("Ventas")]  
    public class Venta
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

    }
}
