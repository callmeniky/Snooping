using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MardomEvaluationTest.Repositorios.Servicios;
using MardomEvaluationTest.Infraestructure.ViewModels;
using WebMatrix.WebData;
using MardomEvaluationTest.Filters;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;

namespace MardomEvaluationTest.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();

        public async Task <ActionResult> Index(string mensaje = "")
        {
            List<SnoopViewModel> lstSnoops = new List<SnoopViewModel>();
            ViewBag.Message = mensaje;

            if (Request.IsAuthenticated)
            {
                //var snoop = new Snoop();
                //lstSnoops = snoop.ListarSnoops(WebSecurity.CurrentUserId);
                using (client = new HttpClient())
                {
                    var wsUrl = ConfigurationManager.AppSettings["UrlSnoopingWS"].ToString();

                    client.BaseAddress = new Uri(wsUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync
                        (string.Format("api/Snoop?usuarioId={0}", WebSecurity.CurrentUserId));

                    if (response.IsSuccessStatusCode)
                    {
                        lstSnoops = await response.Content.ReadAsAsync<List<SnoopViewModel>>();
                    }
                }
            }
            else if (!String.IsNullOrEmpty(mensaje))
                ViewBag.Error = mensaje;

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
