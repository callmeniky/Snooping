using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snooping.Infraestructure.ViewModels;
using Snooping.Infraestructure.InputModels;
using Snooping.Models;
using Snooping.Servicios.Interfaces;

namespace Snooping.Servicios.Servicios
{
    class Follow: IFollow
    {
        private SnoopingDBEntities _snoopingDB = new SnoopingDBEntities();

        //u => User
        public bool Seguir(string uFollower, string uFollowed)
        {
            bool result = false;
            var follow = new Follows();
            var followerCount = new FollowsCount();
            var followedCount = new FollowsCount();

            var follower = _snoopingDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollower.Trim());

            var followed = _snoopingDB.UserProfile.FirstOrDefault(
                r => r.UserName == uFollowed.Trim());


            follow = new Follows()
            {
                UserFollowerID = follower.UserID,
                UserFollowedID = followed.UserID,
                DateFollow = DateTime.Now
                
            };

            _snoopingDB.Follows.Add(follow);


            followedCount = _snoopingDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserID == followed.UserID);

            if (followedCount == null)
            {
                followedCount = new FollowsCount()
                 {
                     UsersInfo = followed.UsersInfo.FirstOrDefault(),
                     FollowersCount =+ 1
                 };

                _snoopingDB.FollowsCount.Add(followedCount);
            }else
            {
                followedCount.FollowersCount += 1;
            }

            followerCount = _snoopingDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserID == follower.UserID);

            if (followerCount == null)
            {
                followerCount = new FollowsCount()
                 {
                     UsersInfo = follower.UsersInfo.FirstOrDefault(),
                     FollowedCount =+ 1
                 };

                _snoopingDB.FollowsCount.Add(followerCount);
            }else
            {
                followerCount.FollowedCount += 1;
            }

            result = _snoopingDB.SaveChanges() > 0 ? true : false;

            return result;
        }

        public bool DejarDeSeguir(int uFollower, string uFollowed)
        {
            bool result = false;

            var follow = _snoopingDB.Follows.FirstOrDefault(
                r => r.UserFollowerID == uFollower
                && r.UserProfile.UserName == uFollowed);

            _snoopingDB.Follows.Remove(follow);

            var followedCount = _snoopingDB.FollowsCount.FirstOrDefault(
                r => r.UsersInfo.UserProfile.UserName == uFollowed.Trim());

            followedCount.FollowersCount -= 1;

            var followerCount = _snoopingDB.FollowsCount.FirstOrDefault(
            r => r.UsersInfo.UserID == uFollower);

            followerCount.FollowedCount -= 1;
          
            result = _snoopingDB.SaveChanges() > 0 ? true : false;

            return result;
        }

        public bool VerificarEsSeguidor(string followed, int currentUser)
        {
           var esSeguidor = _snoopingDB.Follows.FirstOrDefault(
              r => r.UserFollowerID == currentUser 
                  && r.UserProfile.UserName == followed) == null ? false : true;

           return esSeguidor;
        }
    }
}