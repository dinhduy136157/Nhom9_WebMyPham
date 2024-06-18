using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Orders
    {
        public int order_id { get; set; }
        public DateTime order_date {  get; set; }
        public decimal total_price { get; set; }
        public int Customer_custo {  get; set; }
        public int Payment_payme { get; set; }
        public int Shipmen_shipm {  get; set; }
        public Orders() { }
        public Orders(int order_id, DateTime order_date, decimal total_price, int customer_custo, int payment_payme, int shipmen_shipm)
        {
            this.order_id = order_id;
            this.order_date = order_date;
            this.total_price = total_price;
            Customer_custo = customer_custo;
            Payment_payme = payment_payme;
            Shipmen_shipm = shipmen_shipm;
        }
    }
}   