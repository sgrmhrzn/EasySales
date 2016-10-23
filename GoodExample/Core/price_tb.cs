using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    [Table("price_tb")]  
    public class price_tb
    {
        [Key]
        public int stock_id {get; set; }

        public Double? selling_price { get; set; }

        public Double? cost_price { get; set; }
        public Double? margin { get; set; }

        public virtual stock_tb stocks { get; set; }

        //public virtual stock_tb stocks { get; set; }
    }
}