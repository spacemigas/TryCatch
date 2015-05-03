using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : ApiController
    {
        public void Post([FromBody]string value)
        {
            Debugger.Break();
        }
    }
}