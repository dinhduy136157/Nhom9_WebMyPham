using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Wishlist
    {
        public int wishlist_id { get; set; }
        public int Customer_customer_id {  get; set; }
        public int Product_product_id {  get; set; }
        public Wishlist() { }
        public Wishlist(int wishlist_id, int customer_customer_id, int product_product_id)
        {
            this.wishlist_id = wishlist_id;
            Customer_customer_id = customer_customer_id;
            Product_product_id = product_product_id;
        }
    }
}