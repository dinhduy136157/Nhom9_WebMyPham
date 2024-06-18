using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Payment
    {
        public int payment_id {  get; set; }
        public DateTime payment_date { get; set; }
        public string payment_mothod { get; set; }
        public decimal amout { get; set; }
        public int Customer_customer {  get; set; }
        public Payment() { }
        public Payment(int payment_id, DateTime payment_date, string payment_mothod, decimal amout, int customer_customer)
        {
            this.payment_id = payment_id;
            this.payment_date = payment_date;
            this.payment_mothod = payment_mothod;
            this.amout = amout;
            Customer_customer = customer_customer;
        }
    }
}