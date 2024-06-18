using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Cart
    {
        public int cart_id { get; set; }
        public int quantity { get; set; }
        public int Customer_customer_id { get; set; }
        public int Product_product_id { get; set; }
        public Cart() { }
        public Cart(int cart_id, int quantity, int customer_customer_id, int product_product_id)
        {
            this.cart_id = cart_id;
            this.quantity = quantity;
            Customer_customer_id = customer_customer_id;
            Product_product_id = product_product_id;
        }
    }
}