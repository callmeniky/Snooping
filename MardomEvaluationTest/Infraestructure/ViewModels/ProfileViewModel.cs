using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MardomEvaluationTest.Models;

namespace MardomEvaluationTest.Infraestructure.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel() { }

        public ProfileViewModel(UsersInfo userInfo)
        {
            UserName = userInfo.UserProfile.UserName;
            FullName = userInfo.FullName;
            Photo = userInfo.Photo;

        }

        public ProfileViewModel(VwProfileInfo userInfo)
        {
            UserName = userInfo.UserName;
            FullName = userInfo.FullName;
            Photo = userInfo.Photo;
            Followed = userInfo.FollowedCount;
            Followers = userInfo.FollowersCount;
        }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public byte[] Photo { get; set; }
        public int Followers { get; set; }
        public int Followed { get; set; }
        public bool Follow { get; set; }

    }
}