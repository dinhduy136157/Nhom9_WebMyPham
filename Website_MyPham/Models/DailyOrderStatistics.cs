using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class DailyOrderStatistics
    {
        public DateTime OrderDate { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}