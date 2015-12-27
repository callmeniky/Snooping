using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Models;

namespace MardomEvaluationTest.Models.BusinessLogic
{
    public class Follow
    {
        private SnoopingDBEntities _snoopindDB = new SnoopingDBEntities();

        //u => User
        public bool Seguir(string uFollower, string uFollowed)
        {
            bool result = false;
            var follow = new Follows();
            var followerCount = new FollowsCount();
            var followedCount = new FollowsCount();

            var follower = _snoopindDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollower.Trim());

            var followed = _snoopindDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollowed.Trim());


            follow = new Follows()
            {
                UserFollowerID = follower.UserID,
                UserFollowedID = followed.UserID,
                DateFollow = DateTime.Now
                
            };

            _snoopindDB.Follows.Add(follow);


            followedCount = _snoopindDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserID == followed.UserID);

            if (followedCount == null)
            {
                followedCount = new FollowsCount()
                 {
                     UsersInfo = followed.UsersInfo.FirstOrDefault(),
                     FollowersCount = +1
                 };

                _snoopindDB.FollowsCount.Add(followedCount);
            }else
            {
                followedCount.FollowersCount = +1;
            }

            followerCount = _snoopindDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserID == follower.UserID);

            if (followerCount == null)
            {
                followerCount = new FollowsCount()
                 {
                     UsersInfo = follower.UsersInfo.FirstOrDefault(),
                     FollowedCount = +1
                 };

                _snoopindDB.FollowsCount.Add(followerCount);
            }else
            {
                followerCount.FollowedCount =+ 1;
            }

            result = _snoopindDB.SaveChanges() > 0 ? true : false;

            return result;
        }

        public bool DejarDeSeguir(string uFollower, string uFollowed)
        {
            bool result = false;

            var follower = _snoopindDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollower.Trim());

            var followed = _snoopindDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollowed.Trim());

            var newFollow = new Follows()
            {
                UserFollowerID = follower.UserID,
                UserFollowedID = followed.UserID,
                DateFollow = DateTime.Now

            };

            var followedCount = new FollowsCount()
            {
                UsersInfo = followed.UsersInfo.FirstOrDefault(),
                FollowedCount = +1
            };

            var followerCount = new FollowsCount()
            {
                UsersInfo = follower.UsersInfo.FirstOrDefault(),
                FollowersCount = +1
            };

            result = _snoopindDB.SaveChanges() > 0 ? true : false;

            return result;
        }
    }
}