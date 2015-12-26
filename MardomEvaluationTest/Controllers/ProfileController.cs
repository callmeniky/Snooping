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

            var userInfo = _dbContext.UsersInfo.First(r => r.UserID == userId);

            userInfo.Photo = userPhoto.Foto;

            bool result =  _dbContext.SaveChanges() > 0 ? true : false;

            return Json(new { Result = result });
        }

        public string ObtenerFoto()
        {
            var userId = WebSecurity.CurrentUserId;
            var userPhoto = _dbContext.UsersInfo.First(
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
            var userPhoto = _dbContext.UsersInfo.First(r => r.UserProfile.UserName == username).Photo;

            var imgSrc = string.Empty;

            if (userPhoto != null)
            {
                var base64 = Convert.ToBase64String(userPhoto);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            }

            return imgSrc;
        }

  
        public class UserPhoto
        {
            public byte[] Foto { get; set; }
        }

    }
}
