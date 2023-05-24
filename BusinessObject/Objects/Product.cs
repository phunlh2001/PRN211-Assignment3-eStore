using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject.Objects
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Category cannot be empty")]
        [Range(1, 99_999, ErrorMessage = "ID must be greater than 0")]
        public int CategoryId { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name cannot be empty")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Weight cannot be empty")]
        [Range(1, 1_000_000, ErrorMessage = "Weight must be greater than 0")]
        public string Weight { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        [Range(1, 1_000_000, ErrorMessage = "Price must be greater than 0")]
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "Stock cannot be empty")]
        [Range(1, 100, ErrorMessage = "Stock must be 1-100")]
        public int UnitslnStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
