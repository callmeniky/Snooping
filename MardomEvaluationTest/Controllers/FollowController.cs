using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models.BusinessLogic;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Infraestructure.ViewModels;
using WebMatrix.WebData;

namespace MardomEvaluationTest.Controllers
{
    public class FollowController : Controller
    {
        //
        // GET: /Follow/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DejarDeSeguir(string followed)
        {
            bool result = false;
            var objFollow = new Follow();
            string follower = WebMatrix.WebData.WebSecurity.CurrentUserName;

            result = objFollow.DejarDeSeguir(follower, followed);

            return Json(new { Result = result });

        }

        public ActionResult Seguir(string followed)
        {
            bool result = false;
            var objFollow = new Follow();
            string follower = WebMatrix.WebData.WebSecurity.CurrentUserName;
          
            result = objFollow.Seguir(follower, followed);      

            return Json(new { Result = result });
        }

    }
}
