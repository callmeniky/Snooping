using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.BusinessLogic.Servicios;
using MardomEvaluationTest.Infraestructure.ViewModels;
using WebMatrix.WebData;
using MardomEvaluationTest.Filters;

namespace MardomEvaluationTest.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public ActionResult Index(string mensaje = "")
        {
            List<SnoopViewModel> lstSnoops = new List<SnoopViewModel>();
            ViewBag.Message = mensaje;

            if(Request.IsAuthenticated)
            {
                var snoop = new Snoop();
                lstSnoops = snoop.ListarSnoops(WebSecurity.CurrentUserId);
            }

            return View(lstSnoops);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
