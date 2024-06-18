using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Shipment
    {
        public int shipment_id { get; set; }
        public DateTime shipment_date {  get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string sate { get; set; }
        public string zip_code {  get; set; }
        public int Customer_custom { get; set; }
        public Shipment() { }
        public Shipment(int shipment_id, DateTime shipment_date, string address, string city, string sate, string zip_code, int customer_custom)
        {
            this.shipment_id = shipment_id;
            this.shipment_date = shipment_date;
            this.address = address;
            this.city = city;
            this.sate = sate;
            this.zip_code = zip_code;
            Customer_custom = customer_custom;
        }
    }
}