using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    public class creditAccount_tb
    {
        [Key]
        public int credit_id { get; set; }

        public DateTime date { get; set; }

        public int bill_no { get; set; }

        public int voucher_no { get; set; }

        public int customer_id { get; set; }

        public Double? debit_amount { get; set; }

        public Double? credit_amount { get; set; }

        public Double? balance { get; set; }

        public string narration { get; set; }

        public virtual customer_tb customers {get;set;}
    }
}