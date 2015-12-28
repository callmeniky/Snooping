using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WSSnooping.Models;

namespace WSSnooping.Utilities
{
    public class Hashtag
    {
        private SnoopingDBEntities _snoopDb = new SnoopingDBEntities();

        public static string GetHashTag(string urlText)
        {
            Regex urlregex = new Regex(@"(#)((?:[A-Za-z0-9-_]*))", RegexOptions.IgnoreCase
               | RegexOptions.Compiled);
            return urlregex.Replace(urlText, "<a href=\"/Hashtag/Buscar?criterio=$2\" style=\"color: #f68b1f;\">$1$2</a>");
        }

    }
}