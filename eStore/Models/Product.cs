
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models
{
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        [Column("ProductName")]
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Weight { get; set; }
        public double UnitPrice { get; set; }
        public int UnitslnStock { get; set; }

        //Config foreign key
        [ForeignKey("ProductID")]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}