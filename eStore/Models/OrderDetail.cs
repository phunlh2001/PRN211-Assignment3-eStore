using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models
{
    public class OrderDetail
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }
        public virtual Order Oder { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}