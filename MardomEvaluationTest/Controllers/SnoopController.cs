using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Filters;
using System.Web.Security;
using System.Security.Policy;
using MardomEvaluationTest.Utilities;
using MardomEvaluationTest.Repositorios.Servicios;
using WebMatrix.WebData;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MardomEvaluationTest.Controllers
{
    [InitializeSimpleMembership]
    public class SnoopController : Controller
    {
        //
        // GET: /Snoop/
        private SnoopingDBEntities _contextDB = new SnoopingDBEntities();

        public ActionResult Index()
        {
            var snoop = new Snoop();
            var lstSnoopsView = snoop.ListarSnoopsSiguiendo(WebSecurity.CurrentUserId);

            return View("_listSnoops", lstSnoopsView);
        }

        public ActionResult Profile()
        {
            int followers = 0;
            int followed = 0;

            var username = Membership.GetUser().UserName;

            var snoop = new Snoop();
            var lstSnoopsView = snoop.ObtenerSnoopPerfil(username, ref followed, ref followers);

            ViewBag.Followers = followers;
            ViewBag.Followed = followed;

            return View("Index", lstSnoopsView);
        }
        
        public ActionResult AgregarSnoop(SnoopInputModel snoopInputModel)
        {
            var guardar = false;
            int userId = WebMatrix.WebData.WebSecurity.CurrentUserId;

            if (ModelState.IsValid)
            {
                snoopInputModel.UserID = userId;
                var snoop = new Snoop();
               guardar = snoop.AgregarSnoop(snoopInputModel);
            }

            return Json(new { Result = guardar });
        }


    }
}
