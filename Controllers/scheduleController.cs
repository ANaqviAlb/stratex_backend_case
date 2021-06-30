using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using BackendCase.Model;
using BackendCase.NewFolder1;

namespace BackendCase.Controllers
{
    public class scheduleController : ApiController
    {
        scheduleSlots slots = new scheduleSlots();
        public IEnumerable<Employees> Get()
        {
            var allslots =slots.slots();
            return allslots;
        }
        public string Get(int id)
        {
            return "value";
        }
    }
}
