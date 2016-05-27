using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snooping.Models;
using Snooping.Infraestructure.ViewModels;
using Snooping.Infraestructure.InputModels;
using Snooping.Filters;
using System.Web.Security;
using System.Security.Policy;
using Snooping.Utilities;
using Snooping.Servicios.Servicios;
using WebMatrix.WebData;
using System.Net.Http;
using System.Net.Http.Headers;
using Snooping.Servicios;

namespace Snooping.Controllers
{
    [InitializeSimpleMembership]
    public class SnoopController : Controller
    {
        //
        // GET: /Snoop/
       
        public ActionResult Index()
        {
           using (var snoop = FactoriaServicios.GetSnoopInstance())
           { 
             var lstSnoopsView = snoop.ListarSnoopsSiguiendo(WebSecurity.CurrentUserId);

             return View("_listSnoops", lstSnoopsView);
            }
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
