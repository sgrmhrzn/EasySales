using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasySale.Core
{
    public class catagory_tb
    {

        [Key]
        public int cat_id { get; set; }

        public string catagory_name { get; set; }

    }
}