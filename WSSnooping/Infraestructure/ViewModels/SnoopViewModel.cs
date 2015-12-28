using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSSnooping.Models;

namespace WSSnooping.Infraestructure.ViewModels
{
    public class SnoopViewModel
    {
        
        public SnoopViewModel()
        {

        }

        public SnoopViewModel(Snoops snoop)
        {
            SnoopID = snoop.SnoopID;
            UserName = snoop.UserProfile.UserName;
            FullName = snoop.UserProfile.UsersInfo.First().FullName;
            Photo = snoop.UserProfile.UsersInfo.First().Photo;
            Snoop = snoop.Snoop;
            Image = snoop.ImageGuid.HasValue ? snoop.Images.ImageBin : null;            
        }

        public SnoopViewModel(VwSnoopsFollowed vwSnoops)
        {
            SnoopID = vwSnoops.SnoopID;
            UserName = vwSnoops.UserName;
            FullName = vwSnoops.FullName;
            Photo = vwSnoops.Photo;
            Snoop = vwSnoops.Snoop;
            Image = vwSnoops.ImageBin;
        }

        public int SnoopID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte[] Photo { get; set; }
        public string Snoop { get; set; }
        public byte[] Image { get; set; }
    
    }
}