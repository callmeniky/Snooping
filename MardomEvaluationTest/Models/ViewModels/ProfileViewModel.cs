using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MardomEvaluationTest.Models.ViewModels
{
    public class ProfileViewModel
    {


        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Followers { get; set; }
        public int Followed { get; set; }
        public bool Follow { get; set; }

    }
}