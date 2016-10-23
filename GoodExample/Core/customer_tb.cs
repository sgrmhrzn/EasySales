using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    public class customer_tb
    {

        [Key]
        public int customer_id { get; set; }

        public string customer_name { get; set; }

        public string contact { get; set; }

        public string address { get; set; }
    }
}