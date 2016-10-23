using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    [Table("stock_tb")]  
    public class stock_tb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stock_id { get; set; }

        public string barCode { get; set; }

        public string product_des { get; set; }

        public string catagory { get; set; }

        public double? qty_left { get; set; }

        public string vendor { get; set; }

        public string item_code { get; set; }

        [ForeignKey("stock_id")]
        public virtual price_tb prices { get; set; }

    }
}