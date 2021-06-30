using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendCase.Model
{
    public class Shift
    {
        [Key]
        public Int64 id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Int64 ActivityID { get; set; }
        public Int64 EmployeeID { get; set; }
    }
}