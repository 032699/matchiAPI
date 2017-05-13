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
    public class PostController : ApiController
    {
        private PostDataService postService = new PostDataService();
        private const string outputMsg = "success";
      

        [Route("api/post/post")]
        [HttpPost]
        public string Post([FromBody] user_post post)
        {


            //  var msg = ZeroMQServiceProvider.LookupServiceMessenger("", "");
            //  var result = msg.Result;
            try
            {
                postService.AddPost(post);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [Route("api/post/get_user_posts")]
        [HttpGet]
        public List<user_post> get_user_post(int user_id, int pageSize, int page)
        {
            return postService.GetUserPosts(user_id, pageSize, page);
        }

        [Route("api/post/get_nearby_posts")]
        [HttpGet]
        public List<getNearbyPosts_Result> GetNearByPosts(decimal latitude, decimal longitude, int distance_in_km)
        {
            
                return postService.GetPostsByDistance(latitude, longitude, distance_in_km);
            
        }

        [Route("api/post/delete_post")]
        [HttpPost]
        public string DeletePost(Int64 user_post_id)
        {
            try
            {
                postService.DeletePost(user_post_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("api/post/report_post")]
        [HttpPost]
        public string ReportPost(Int64 user_post_id)
        {
            try
            {
                postService.ReportPost(user_post_id);
                return outputMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [Route("api/post/search_filtered_posts")]
        [HttpGet]
        public List<user_post> SearchPostByActivitiesAndTopics(string searchText, string topics_id_comma_delimeted, string activities_id_comma_delimeted)
        {
            return postService.SearchPostByActivitiesAndTopics(searchText, topics_id_comma_delimeted, activities_id_comma_delimeted);
        }
    }
}
