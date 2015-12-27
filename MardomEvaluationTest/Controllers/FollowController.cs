using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models.BusinessLogic;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Infraestructure.ViewModels;

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

        public ActionResult Seguir(string followed)
        {
            var objFollow = new Follow();
            string follower = WebMatrix.WebData.WebSecurity.CurrentUserName;

            bool result = objFollow.Seguir(follower, followed);

            return Json(new { Result = result });
        }

    }
}
