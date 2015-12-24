using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models;

namespace MardomEvaluationTest.Controllers
{
    public class BasicController : Controller
    {
        //
        // GET: /Basic/

      

        public BasicController()
        {
             SnoopingDBEntities _contextDB = new SnoopingDBEntities();
        }

    }
}
