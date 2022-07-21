//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class BookFineTable
    {
        public int BookFineID { get; set; }
        [Required(ErrorMessage = "Please Select Employee!")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Please Select Book!")]
        public int BookID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Select Date!")]
        [DataType(DataType.Date)]
        public System.DateTime FineDate { get; set; }
        [Required(ErrorMessage = "Please Enter Penalty!")]
        public double FineAmount { get; set; }
        [Required(ErrorMessage = "Please Enter Recieve fine/Penalty Amount!")]
        public Nullable<double> ReceiveAmount { get; set; }
        [Required(ErrorMessage = "Please Enter No of Days!")]
        public int NoOfDays { get; set; }
    
        public virtual BookTable BookTable { get; set; }
        public virtual EmployeeTable EmployeeTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}