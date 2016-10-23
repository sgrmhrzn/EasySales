using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    public class salesDetail_tb
    {
        [Key]
        public int bill_ID { get; set; }

        public int bill_no { get; set; }

        public DateTime date { get; set; }

        public string sales_product_des { get; set; }

        public string barCode { get; set; }

        public Double? qty { get; set; }

        public Double? sales_price { get; set; }

        public Double? total_price { get; set; }

        public string unit { get; set; }

        public int? user_id { get; set; }

        public string vendor { get; set; }

    }
}