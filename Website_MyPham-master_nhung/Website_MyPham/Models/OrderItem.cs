using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class OrderItem
    {
        public int order_item_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int Product_prod { get; set; }
        public int Order_order_i { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }

        public Orders Orders { get; set; }
        public string status {  get; set; }

        public OrderItem() { }
        public OrderItem(int order_item_id,  int quantity, decimal price, int product_prod, int Order_order_i, Customer customer, Product product, Orders orders, string status) 
        {
            this.order_item_id = order_item_id;
            this.quantity = quantity;
            this.price = price;
            this.Product_prod = product_prod;
            this.Order_order_i = Order_order_i;
            Customer = customer;
            Product = product;
            Orders = orders;
            this.status = status;
        }


    }
}