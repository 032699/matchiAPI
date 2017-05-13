using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class QueryModel
    {
        public class PostsModel
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<user_post> user_posts { get; set; }
        }


      


        public class BookmarkModel
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<user_bookmark> user_bookmarks { get; set; }
        }


        public class FollowersModel
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<user_follower> user_followers { get; set; }
        }
 
        public class InboxThreadModel
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<post_thread> inbox_thread { get; set; }
        }


       

     


        public class UserModel
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<user> users { get; set; }
        }

        public class ComposeModel
        {
            public int user_id_to { get; set; }
            public string subject { get; set; }
            public int user_id_from { get; set; }
            public string user_name_from { get; set; }
            public string user_avatar_from { get; set; }
            public string message { get; set; }
            public string full_name_from { get; set; }

        }
    }
}
