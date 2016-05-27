using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snooping.Utilities;

namespace Snooping.Controllers
{
    public class HashtagController : Controller
    {
        //
        // GET: /Hashtag/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string criterio)
        {
            HashTag hashtag = new HashTag();

            return PartialView("_hashtag", hashtag.ObtenerSnoopsByHastag(criterio));
        }
    }
}
