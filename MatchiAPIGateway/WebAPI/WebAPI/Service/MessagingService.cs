using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatchiDataProvider;
using Newtonsoft.Json;
using MatchiWebAPI.Providers;
namespace MatchiWebAPI.Service
{
    public class MessagingService
    {
        public static string SignUp(user _user)
        {
            string message = JsonConvert.SerializeObject(_user);

            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "signup");

            return task.Result;
        }

        public static string UpdateUser(user _user)
        {
            string message = "";


            message = JsonConvert.SerializeObject(_user);

            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "update_user");

            return task.Result;
        }

        public static string AddPost(user_post _post)
        {

            string message = JsonConvert.SerializeObject(_post);

            var task = ZeroMQServiceProvider.PostServiceMessenger(message, "post");

            return task.Result;
        }

        public static List<user_post> GetUserPosts(Int64 user_id, int page, int pageSize)
        {
            string message = user_id + "_" + page + "_" + pageSize;
            var task = ZeroMQServiceProvider.PostServiceMessenger(message, "get_user_posts");

            var response = JsonConvert.DeserializeObject<List<user_post>>(task.Result);

            return response;
        }


        public static List<user_post> GetNearbyPosts(string latitude, string longitude, int page, int pageSize)
        {
            string message = latitude + "_" +  longitude +"_" + page + "_" + pageSize;
            var task = ZeroMQServiceProvider.PostServiceMessenger(message, "get_nearby_post");

            var response = JsonConvert.DeserializeObject<List<user_post>>(task.Result);

            return response;
        }


        public static user GetUserByUserName(string user_name)
        {
            string message = user_name;
            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "get_user_by_user_name");

            var response = (user)JsonConvert.DeserializeObject<user>(task.Result);
            return response;

        }
        public static user GetUserById(string user_id)
        {
            string message = user_id;
            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "get_user_id");

            var response = (user)JsonConvert.DeserializeObject<user>(task.Result);
            return response;

        }

        public static string HeartPost(int user_post_id, string user_name, int user_id)
        {
            string message = user_post_id + "_" + user_name + "_" + user_id;

            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "heart_post");
            return task.Result;
        }

        public static string UnHeartPost(int user_post_id, string user_name, int user_id)
        {
            string message = user_post_id + "_" + user_name + "_" + user_id;

            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "unheart_post");
            return task.Result;
        }

        public static string FollowUser(int follower_user_id, string follower_user_handle, string follower_user_avatar,
           string follower_full_name, int user_id)
        {


            user_follower _user_follower = new user_follower
            {
                follower_full_name = follower_full_name,
                follower_user_avatar = follower_user_avatar,
                follower_user_handle = follower_user_handle,
                user_id = user_id,
                follower_user_id = follower_user_id

            };

            string message = JsonConvert.SerializeObject(_user_follower);
            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "follow_user");
            return task.Result;
        }

        public static string UnFollowUser(int follower_user_id, int user_id)
        {
            string message = follower_user_id + "_" + user_id;
            var task = ZeroMQServiceProvider.UserServiceMessenger(message, "unfollow_user");
            return task.Result;
        }

        public static List<user_follower> GetUserFollowers(Int64 user_id, int page, int pageSize)
        {
            string message = user_id + "_" + page + "_" + pageSize;
           
            var task = ZeroMQServiceProvider.PostServiceMessenger(message, "get_user_followers");


            List<user_follower> responseModel =  JsonConvert.DeserializeObject<List<user_follower>>(task.Result);
            return responseModel;
        }

        public static List<user_following> GetUserFollowing(int  user_id, int page, int pageSize)
        {
            string message = user_id + "_" + page + "_" + pageSize;

            var task = ZeroMQServiceProvider.PostServiceMessenger(message, "get_user_following");
            List<user_following> responseModel = JsonConvert.DeserializeObject<List<user_following>>(task.Result);
            return responseModel;
        }
    }
}