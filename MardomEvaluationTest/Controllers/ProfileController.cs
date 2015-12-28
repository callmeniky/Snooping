using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Models;
using System.Web.Security;
using WebMatrix.WebData;
using System.Text;
using MardomEvaluationTest.Filters;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.BusinessLogic.Servicios;


namespace MardomEvaluationTest.Controllers
{
    [InitializeSimpleMembership]
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/
        private SnoopingDBEntities _dbContext = new SnoopingDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CambiarFoto(UserPhoto userPhoto)
        {
            var userId = WebMatrix.WebData.WebSecurity.CurrentUserId;

            var userInfo = _dbContext.UsersInfo.FirstOrDefault(r => r.UserID == userId);

            userInfo.Photo = userPhoto.Foto;

            bool result =  _dbContext.SaveChanges() > 0 ? true : false;

            return Json(new { Result = result });
        }

        public string ObtenerFoto()
        {
            byte[] userPhoto = null;
            var userId = WebSecurity.CurrentUserId;

            if(userId > 0)
              userPhoto = _dbContext.UsersInfo.FirstOrDefault(
                r => r.UserID == userId).Photo;

            var imgSrc = string.Empty;
            if(userPhoto != null)
                { 
                var base64 = Convert.ToBase64String(userPhoto);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                }

            return imgSrc;
        }

        public string ObtenerFotoPorUsuario(string username)
        {
            var userPhoto = _dbContext.UsersInfo.FirstOrDefault(r => r.UserProfile.UserName == username).Photo;

            var imgSrc = string.Empty;

            if (userPhoto != null)
            {
                var base64 = Convert.ToBase64String(userPhoto);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            }

            return imgSrc;
        }

        public ActionResult Perfiles(string criterio)
        {
            int userId = WebSecurity.CurrentUserId;
            ProfileViewModel profileView = new ProfileViewModel();

            var perfiles = new Perfiles();
            var lstPerfiles = perfiles.ObtenerPerfilesPorNombre(criterio, userId);
            var profileInfo = perfiles.ObtenerInfoPorID(userId);

            ViewBag.Followers = profileInfo.Followers;
            ViewBag.Followed = profileInfo.Followed;
            ViewBag.FullName = profileInfo.FullName;

            return View("_perfiles", lstPerfiles);
        }

        public ActionResult BuscarPerfil(string username)
        {
            var perfiles = new Perfiles();
            int followers = 0;
            int followed = 0;
            bool esSeguidor = false;

            var perfil = perfiles.ObtenerPerfil(username, WebSecurity.CurrentUserId, out followers, out followed, ref esSeguidor);
           
            var infoFollow = _dbContext.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserProfile.UserName == username.Trim());

            ViewBag.Followers = followers;
            ViewBag.Followed = followed;
            ViewBag.EsSeguidor = esSeguidor;

            return View("_perfil", perfil);
        }
  
        public class UserPhoto
        {
            public byte[] Foto { get; set; }
        }

    }
}
