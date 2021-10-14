using Domain.Enums;
using Domain.Enums.Inventories;

namespace Domain.Entities.Inventories
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }         
        public MeasureUnit UnidadMedida { get; set; }
        public InventoryMethod InventoryMethod { get; set; }
    }
}
