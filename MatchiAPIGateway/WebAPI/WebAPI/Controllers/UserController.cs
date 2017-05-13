using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatchiWebAPI.Providers;
using System.Threading.Tasks;
using MatchiPostDataService;
using MatchiUserService;
using MatchiDataProvider;

namespace MatchiWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private UserDataService userService = new UserDataService();
        private const string outputMsg = "success";

        [Route("api/user/signup")]
        [HttpPost]
        public string  SignUp([FromBody] user _user)
        {


            //  var msg = ZeroMQServiceProvider.LookupServiceMessenger("", "");
            //  var result = msg.Result;
           try
            {
                userService.SignUp(_user);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            
        }

        [Route("api/user/login")]
        [HttpGet]
        public user  Login(string userNameOrEmail, string password)
        {

            try
            {
                return userService.Login(userNameOrEmail,password);
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [Route("api/user/update_user")]
        [HttpPost]
        public string UpdateUser([FromBody] user _user)
        {


            //  var msg = ZeroMQServiceProvider.LookupServiceMessenger("", "");
            //  var result = msg.Result;
            try
            {
                userService.UpdateUser(_user);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        [Route("api/user/get_user_by_username")]
        [HttpGet]
        public user GetUserByUsername(string userName)
        {

            try
            {
                return userService.GetUserByHandle(userName);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("api/user/get_user_by_id")]
        [HttpGet]
        public user GetUserById(int  userId)
        {

            try
            {
                return userService.GetUserById(userId);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [Route("api/user/get_user_bookmarks")]
        [HttpGet]
        public List<user_bookmark> GetUserBookmarks(int userId, int page, int pageSize)
        {

            try
            {
                return userService.GetUserBookmarks(userId,page, pageSize);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [Route("api/user/delete_user_bookmark")]
        [HttpPost]
        public string DeleteUserBookmark( int user_bookmark_id)
        {
            try
            {
                userService.DeleteUserBookmark(user_bookmark_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("api/user/add_user_bookmark")]
        [HttpPost]
        public string AddUserBookmark([FromBody] user_bookmark bookmark)
        {
            try
            {
                userService.AddUserBookmark(bookmark);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("api/user/get_user_interest")]
        [HttpGet]
        public List<user_interest> GetUserInterests(int userId, int page, int pageSize)
        {

            try
            {
                return userService.GetUserInterest(userId, pageSize, page);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [Route("api/user/add_user_interest")]
        [HttpPost]
        public string AddUserInterest([FromBody] user_interest interest)
        {
            try
            {
                userService.AddUserInterest(interest);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("api/user/delete_user_interest")]
        [HttpPost]
        public string DeleteUserInterest(int user_interest_id)
        {
            try
            {
                userService.DeleteUserInterest(user_interest_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("api/user/get_user_locations")]
        [HttpGet]
        public List<user_location> GetUserLocations(int userId, int page, int pageSize)
        {

            try
            {
                return userService.GetUserLocations(userId, page, pageSize);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [Route("api/user/delete_user_location")]
        [HttpPost]
        public string DeleteUserLocation(int user_location_id)
        {
            try
            {
                userService.DeleteUserLocation(user_location_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("api/user/add_user_location")]
        [HttpPost]
        public string AddUserLocation([FromBody] user_location location)
        {
            try
            {
                userService.AddUserLocation(location);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       
              [Route("api/user/get_user_post_likes")]
        [HttpGet]
        public List<user_post_like> GetUserPostLikes(int user_id, int page, int pageSize)
        {

            try
            {
                return userService.GetUserPostLikes(user_id, page, pageSize);

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [Route("api/user/add_post_like")]
        [HttpPost]
        public string AddPostLike([FromBody] user_post_like like)
        {
            try
            {
                userService.AddPostLike(like);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("api/user/delete_user_post_like")]
        [HttpPost]
        public string DeleteUserPostLike(int user_post_like_id)
        {  
            try
            {
                userService.DeletePostLike(user_post_like_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
    }
