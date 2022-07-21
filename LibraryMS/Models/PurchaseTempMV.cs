using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    public class PurchaseTempMV
    {
        public int PurTemID { get; set; }
        [Required(ErrorMessage = "Please Select Book!")]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Enter Purchase Qty!")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Enter Purchase Unit Price!")]
        public double UnitPrice { get; set; }
    }
}