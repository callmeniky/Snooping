using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MardomEvaluationTest.Models.ViewModels;
using MardomEvaluationTest.Models;

namespace MardomEvaluationTest.Utilities
{
    public class HashTag
    {

        private SnoopingDBEntities _snoopDb = new SnoopingDBEntities();

        public static string GetHashTag(string urlText)
        {
            Regex urlregex = new Regex(@"(#)((?:[A-Za-z0-9-_]*))", RegexOptions.IgnoreCase
               | RegexOptions.Compiled);
            return urlregex.Replace(urlText, "<a href=\"/Hashtag/Buscar?criterio=$2\" style=\"color: #f68b1f;\">$1$2</a>");
        }

        public List<SnoopViewModel> ObtenerSnoopsByHastag(string hashtag)
        {
            var lstSnoopViewModel = new List<SnoopViewModel>();
            var snoopViewModel = new SnoopViewModel();

            var snoops = _snoopDb.Snoops.Where(
                r => r.Snoop.Contains(hashtag)).ToList();

            foreach(var snoop in snoops)
            {
                snoopViewModel = new SnoopViewModel(snoop);
                if(snoop.Snoop.Contains("#"))
                 snoopViewModel.Snoop = GetHashTag(snoop.Snoop);

                lstSnoopViewModel.Add(snoopViewModel);
            }

            return lstSnoopViewModel;
        }
    }
}