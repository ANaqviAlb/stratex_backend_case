﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendCase.Model
{
    public class Activities
    {
        [Key]
        public Int64 id { get; set; }
        public string name { get; set; }
    }
}