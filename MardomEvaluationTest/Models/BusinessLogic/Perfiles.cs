using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Models;

namespace MardomEvaluationTest.Models.BusinessLogic
{
    public static class Perfiles
    {
        private static SnoopingDBEntities _snoopingDb = new SnoopingDBEntities();

        public static List<ProfileViewModel> ObtenerPerfilesPorNombre(string criterio)
        {
            ProfileViewModel profileView = new ProfileViewModel();
            List<ProfileViewModel> lstProfileView = new List<ProfileViewModel>();

            var perfiles = _snoopingDb.UsersInfo.Where(
                r => r.FullName.Contains(criterio)).ToList();

            if(perfiles.Any())
            {
                foreach(var perfil in perfiles)
                {
                    profileView = new ProfileViewModel(perfil);
                    lstProfileView.Add(profileView);
                }
            }

            return lstProfileView;                
        }

        public static List<SnoopViewModel> ObtenerPerfil(string username)
        {
            SnoopViewModel snoopView = new SnoopViewModel();
            List<SnoopViewModel> lstSnoopView = new List<SnoopViewModel>();

            var perfil = _snoopingDb.Snoops.Where(
                r => r.UserProfile.UserName == username.Trim());
               
            if(perfil.Any())
            {
                foreach(var snoop in perfil)
                {
                    snoopView = new SnoopViewModel(snoop);
                    lstSnoopView.Add(snoopView);
                }
            }

            return lstSnoopView;
        }
    }
}