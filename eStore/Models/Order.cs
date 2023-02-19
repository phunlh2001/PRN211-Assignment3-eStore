using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models
{
    public class Order
    {
        [Key]
        [Column("OrderID")]
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        [Column("RequiredDate")]
        public DateTime? Required { get; set; }
        [Column("ShippedDate")]
        public DateTime? Shipped { get; set; }
        public double? Freight { get; set; }

        //FK
        public int MemberID { get; set; }
        public virtual Member Member { set; get; }

        //Config foreign key
        [ForeignKey("OrderID")]
        public virtual ICollection<OrderDetail> OrderDetails { set; get; }
    }
}