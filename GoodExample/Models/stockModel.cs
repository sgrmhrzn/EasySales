using EasySale.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasySale.Models
{
    public class stockModel 
    {
        public int stock_id { get; set; }

        public string barCode { get; set; }

        public string product_des { get; set; }

        public IList<price_tb> prices { get; set; }
    }
}