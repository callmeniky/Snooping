using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSSnooping.Models;
using WSSnooping.Infraestructure.InputModels;
using WSSnooping.Infraestructure.ViewModels;

namespace WSSnooping.Models.Repositorios.Servicios
{
    public class Snoop
    {
        private SnoopingDBEntities _snoopingDb;

        public Snoop()
        {
            this._snoopingDb = new SnoopingDBEntities();
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

            _snoopingDb.Snoops.Add(snoop);

            return guardar = _snoopingDb.SaveChanges() > 0 ? true : false;
        }

        public List<SnoopViewModel> ListarSnoops(int currentUser)
        {
            List<SnoopViewModel> lstSnoopView = new List<SnoopViewModel>();
            SnoopViewModel snoopView = new SnoopViewModel();

            var lista = _snoopingDb.VwSnoopsFollowed.Where(
                r => r.UserFollowerID == currentUser).ToList();

            foreach (var snoop in lista)
            {
                snoopView = new SnoopViewModel(snoop);
                lstSnoopView.Add(snoopView);
            }

            return lstSnoopView;
        }

    }
}