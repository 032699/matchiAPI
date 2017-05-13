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
 
 
namespace MatchiUserService
{
    public class UserDataService
    {
        public user Login(string email_username, string password)
        {
            user _u = new user();
            try
            {
                using (matchiDbEntities db = new matchiDbEntities())
                {
                    _u = (from u in db.users
                          where (u.email == email_username &&
               u.password == password) || (u.user_handle == email_username
               && u.password == password)
                          select u).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return _u;
        }
    
        public void UpdateUser(user _user)
        {
            using (matchiDbEntities db = new  matchiDbEntities())
            {
                user _u = (from u in db.users
                           where u.user_id == _user.user_id
                           select u).FirstOrDefault();

                if (_u != null)
                {
                                       
                    _u.email = _user.email;
                    _u.full_name = _user.full_name;
                    
                    _u.password = _user.password;
                    _u.user_avatar_url = _user.user_avatar_url;
                    _user.user_handle = _user.user_handle;

                    db.SaveChanges();
                }
            }
        }
        public user  SignUp (user u
                       )
        {


            user _user = new user();

            using (matchiDbEntities db = new  matchiDbEntities())
                {
                  
                    _user.full_name = u.full_name;
                    _user.email = u.email;
                
                    _user.password = u.password;
                    _user.date_joined = DateTime.Now.ToString();
                    _user.user_handle = u.user_handle;
                    _user.user_avatar_url = u.user_avatar_url;
                   
                    _user.is_active = true;
                    db.users.Add(_user);
                    db.SaveChanges();
                
                }
            

            return _user ;
        }

        //FOR PUSH/PULL
     

        public user GetUserByHandle(string user_handle)
        {
            user _user = new user();
            using (matchiDbEntities db = new matchiDbEntities())
            {
                _user = (from u in db.users where u.user_handle == user_handle select u).FirstOrDefault();

            }

            return _user;
        }

        public user GetUserById(Int64 user_id)
        {
            user _user = new user();
            using (matchiDbEntities db = new matchiDbEntities())
            {
                _user = (from u in db.users where u.user_id == user_id select u).FirstOrDefault();

            }

            return _user;
        }

        public List<user_bookmark> GetUserBookmarks (int user_id,   int page, int pageSize)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
               return  (from u in db.user_bookmarks where u.user_id == user_id select u).Take(pageSize).Skip((page - 1) * pageSize).ToList();

            }
        }
        public void AddUserBookmark(user_bookmark bookmark)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                db.user_bookmarks.Add(bookmark);
                db.SaveChanges(); 

            }

        }

        public void DeleteUserBookmark(int user_bookmark_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
               var bookmark =  (from u in db.user_bookmarks where u.user_bookmark_id == user_bookmark_id select u).FirstOrDefault() ;

                db.user_bookmarks.Remove(bookmark);
                db.SaveChanges();
            }
        }

        public List<user_interest> GetUserInterest(int user_id, int pageSize, int page)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                return (from u in db.user_interests where u.user_id == user_id select u).Take(pageSize).Skip((page - 1) * pageSize).ToList();

            }
        }

        public void AddUserInterest(user_interest interest)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                db.user_interests.Add(interest);
                db.SaveChanges();

            }

        }

        public void DeleteUserInterest(int user_interest_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
               var interest = (from u in db.user_interests where u.id == user_interest_id select u).FirstOrDefault();

                db.user_interests.Remove(interest);
                db.SaveChanges();

            }
        }

        public List<user_location> GetUserLocations(int user_id, int page, int pageSize)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                return (from u in db.user_locations where u.user_id== user_id select u).Take(pageSize).Skip((page - 1) * pageSize).ToList(); ;

            }
        }

        public void DeleteUserLocation(int user_location_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                var location = (from u in db.user_locations where u.id == user_location_id select u).FirstOrDefault();
                db.user_locations.Remove(location);
                db.SaveChanges();
            }
        }

        public void AddUserLocation(user_location location)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                db.user_locations.Add(location);
                db.SaveChanges();
            }
        } 

        public List<user_post_like> GetUserPostLikes(int user_id, int page, int pageSize)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                return (from u in db.user_post_likes where u.user_id == user_id select u).Take(pageSize).Skip((page - 1) * pageSize).ToList(); ;

            }
        }
        public void AddPostLike(user_post_like like)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {

                db.user_post_likes.Add(like);
                    db.SaveChanges();
            }
        }
        public void DeletePostLike(int user_post_like_id)
        {
            using (matchiDbEntities db = new matchiDbEntities())
            {
                var unlike =  (from u in db.user_post_likes where u.user_post_like_id == user_post_like_id select u).FirstOrDefault();
                db.user_post_likes.Remove(unlike);
                db.SaveChanges();
            }

        }

    }
}
