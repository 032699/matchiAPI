using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MatchiDataProvider;

using System.Device.Location;
using System.Data.Spatial;
using System.Data.SqlClient;

namespace MatchiPostDataService
{
    public class PostDataService
    {
        public void AddPost(user_post post)

        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                db.user_posts.Add(post);
                db.SaveChanges();
            }
        }

        public List<user_post> GetUserPosts(int user_id, int pageSize, int page)
        {

            using (matchiDbEntities db = new matchiDbEntities())
            {
                return db.user_posts.Where(u => u.user_id == user_id).Take(pageSize).Skip((page - 1) * pageSize).ToList(); ;

            }
        }

        public List<getNearbyPosts_Result> GetPostsByDistance(decimal latitude, decimal longitude, int distance_in_km)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                return  db.getNearbyPosts(longitude, longitude, distance_in_km).OrderBy (x=>x.distance).ToList() ;
            }
        }

        public void DeletePost(Int64 user_post_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                var post_user = db.user_posts.Where(u => u.user_post_id== user_post_id).FirstOrDefault();
                db.user_posts.Remove(post_user);
                db.SaveChanges();
            }
        }

        public void ReportPost(Int64 user_post_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                var post_user = db.user_posts.Where(u => u.user_post_id == user_post_id).FirstOrDefault();
                post_user.is_reported = 1;
                db.SaveChanges();
            }
        }

        public List<user_post> SearchPostByActivitiesAndTopics(string searchText, string topics_id_comma_delimeted, string activities_id_comma_delimeted)
        {
            List<user_post> result = new List<user_post>();
            using (matchiDbEntities db = new matchiDbEntities())
             
            {
                if (searchText != string.Empty && topics_id_comma_delimeted != string.Empty
                    && activities_id_comma_delimeted != string.Empty)
                {
                    string sql = "@select * from user_posts where post_type_id in (@" + topics_id_comma_delimeted + @") 
                    and post_category_id in (" + activities_id_comma_delimeted + @")
                    and (title like '%" + searchText + "%' or description like '%" + searchText + "%'";
                    ;

                    result = db.Database.SqlQuery<user_post>(sql).ToList();
                }else if (searchText == string.Empty && topics_id_comma_delimeted != string.Empty
                    && activities_id_comma_delimeted != string.Empty)
                {
                    string sql = "@select * from user_posts where post_type_id in (@" + topics_id_comma_delimeted + @") 
                    and post_category_id in (" + activities_id_comma_delimeted +  ")";
                   ;
             

                    result = db.Database.SqlQuery<user_post>(sql).ToList();
                }
                else if (searchText != string.Empty && topics_id_comma_delimeted == string.Empty
                   && activities_id_comma_delimeted != string.Empty)
                {
                    string sql = "@select * from user_posts where post_category_id in (" + activities_id_comma_delimeted + @")
                    and (title like '%" + searchText + "%' or description like '%" + searchText + "%'";
                    ;

                    result = db.Database.SqlQuery<user_post>(sql).ToList();
                }
                else if (searchText != string.Empty && topics_id_comma_delimeted != string.Empty
             && activities_id_comma_delimeted == string.Empty)
                {
                    string sql = "@select * from user_posts where post_type_id in (@" + topics_id_comma_delimeted + @") 
                    and (title like '%" + searchText + "%' or description like '%" + searchText + "%'";
                    ;

                    result = db.Database.SqlQuery<user_post>(sql).ToList();
                }
            }
            return result;
        }

    }
}
