using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Models;
using MardomEvaluationTest.Utilities;
using MardomEvaluationTest.Repositorios.Interfaces;
using MardomEvaluationTest.Infraestructure.InputModels;

namespace MardomEvaluationTest.Repositorios.Servicios
{
    public class Snoop: ISnoop
    {
        private SnoopingDBEntities _contextDB = new SnoopingDBEntities();

      public List<SnoopViewModel> ObtenerSnoopPerfil(string username, ref int followed, ref int followers)
        {

            var listSnoobs = _contextDB.Snoops.Where(
               r => r.UserProfile.UserName == username).ToList();

            var followInfo = _contextDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserProfile.UserName == username);

            var lstSnoopsView = new List<SnoopViewModel>();
            var snoopView = new SnoopViewModel();

            followed = followInfo == null ? followed : followInfo.FollowedCount;
            followers = followInfo == null ? followers : followInfo.FollowersCount;

            foreach (var snoop in listSnoobs)
            {
                snoopView = new SnoopViewModel(snoop);
                snoopView.Snoop = HashTag.GetHashTag(snoopView.Snoop);
                lstSnoopsView.Add(snoopView);
            }

            return lstSnoopsView;

        }

      public bool AgregarSnoop(SnoopInputModel snoopInputModel)
      {
          bool guardar = false;

          var snoop = new Snoops()
          {
              Private = snoopInputModel.Private,
              DateSnoop = DateTime.Now,
              Snoop = snoopInputModel.Snoop,
              UserID = snoopInputModel.UserID,
          };

          if (snoopInputModel.Image != null)
          {
              Guid imageGuid = Guid.NewGuid();

              snoop = new Snoops()
              {
                  Private = snoopInputModel.Private,
                  DateSnoop = DateTime.Now,
                  Snoop = snoopInputModel.Snoop,
                  UserID = snoopInputModel.UserID,
                  Images = new Images()
                  {
                      ImageBin = snoopInputModel.Image,
                      ImageGuid = imageGuid
                  },
                  ImageGuid = imageGuid
              };
          }

          _contextDB.Snoops.Add(snoop);

          return guardar = _contextDB.SaveChanges() > 0 ? true : false;
      }


      public List<SnoopViewModel> ListarSnoopsSiguiendo(int userId)
      {
          var listSnoobs = _contextDB.Snoops.Where(
                 r => r.UserID == userId &&
                     r.UserProfile.Follows.Any()).ToList();

          var lstSnoopsView = new List<SnoopViewModel>();
          var snoopView = new SnoopViewModel();

          foreach (var snoop in listSnoobs)
          {
              snoopView = new SnoopViewModel(snoop);
              lstSnoopsView.Add(snoopView);
          }

          return lstSnoopsView;
      }

      public List<SnoopViewModel> ListarSnoops(int currentUser)
      {
          List<SnoopViewModel> lstSnoopView = new List<SnoopViewModel>();
          SnoopViewModel snoopView = new SnoopViewModel();

          var lista = _contextDB.VwSnoopsFollowed.Where(
              r => r.UserFollowerID == currentUser).ToList();
                  
          foreach(var snoop in lista)
          {
              snoopView = new SnoopViewModel(snoop);
              if (snoopView.Snoop.Contains('#'))
                   snoopView.Snoop = HashTag.GetHashTag(snoopView.Snoop);
              lstSnoopView.Add(snoopView);
          }

          return lstSnoopView;
      }
    }
}