using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snooping.Infraestructure.InputModels;
using Snooping.Infraestructure.ViewModels;
using Snooping.Models;
using Snooping.Servicios.Interfaces;
using Snooping.Utilities;

namespace Snooping.Servicios.Servicios
{
    public class Perfiles: IPerfiles
    {
        private static SnoopingDBEntities _snoopingDb = new SnoopingDBEntities();

        public List<ProfileViewModel> ObtenerPerfilesPorNombre(string criterio, int currentUserId)
        {
           
            ProfileViewModel profileView = new ProfileViewModel();
            List<ProfileViewModel> lstProfileView = new List<ProfileViewModel>();

            var perfiles = _snoopingDb.UsersInfo.Where(
                r => r.FullName.Contains(criterio) 
                    && r.UserID != currentUserId).ToList();

            var followInfo = _snoopingDb.FollowsCount.FirstOrDefault(
              r => r.UsersInfo.UserID == currentUserId);

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

        public List<SnoopViewModel> ObtenerPerfil(string username, int current, 
            out int followers, out int followed, ref bool esSeguidor)
        {
            followed = 0;
            followers = 0;
            SnoopViewModel snoopView = new SnoopViewModel();
            List<SnoopViewModel> lstSnoopView = new List<SnoopViewModel>();
            List<Snoops> perfil = new List<Snoops>();

            var followInfo = _snoopingDb.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserProfile.UserName == username.Trim());

            if(followInfo != null)
            {
                followed = followInfo.FollowedCount;
                followers = followInfo.FollowersCount;
            }


           esSeguidor = _snoopingDb.Follows.FirstOrDefault(
                r => r.UserFollowerID == current && r.UserProfile.UserName == username) == null ? false : true;

            if(esSeguidor)
                perfil = _snoopingDb.Snoops.Where(
                    r => r.UserProfile.UserName == username.Trim()).ToList();
            else
                perfil = _snoopingDb.Snoops.Where(
              r => r.UserProfile.UserName == username.Trim() && !r.Private).ToList();
               
            if(perfil.Any())
            {
                foreach(var snoop in perfil)
                {
                    snoopView = new SnoopViewModel(snoop);
                    if (snoopView.Snoop.Contains('#'))
                        snoopView.Snoop = HashTag.GetHashTag(snoopView.Snoop);

                    lstSnoopView.Add(snoopView);
                }
            }

            return lstSnoopView;
        }

        public ProfileViewModel ObtenerInfoPorID(int usuarioId)
        {
            ProfileViewModel profileView = new ProfileViewModel();

            var profile = _snoopingDb.VwProfileInfo.FirstOrDefault(
                r => r.UserID == usuarioId);

            if (profile != null)
                profileView = new ProfileViewModel(profile);

            return profileView;
        }
    }
}