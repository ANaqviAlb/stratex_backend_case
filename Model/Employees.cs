using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendCase.Model
{
    public class Employees
    {
        [Key]
        public Int64 id { get; set; }
        public string name { get; set; }

        public IEnumerable<Shift> shifts { get; set; }
        public IEnumerable<Break> breaks { get; set; }
        public IEnumerable<Leave> leaves { get; set; }



    }
}