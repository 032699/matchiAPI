using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

 
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
 
namespace  MatchiDataProvider
{
    public class matchiDbEntities : DbContext
    {
        public matchiDbEntities()
            : base("name=matchiDbEntities")
        {
        }

   
        public DbSet<post_category> post_categories { get; set; }
        public DbSet<post_thread> post_threads { get; set; }
        public DbSet<post_type> post_types { get; set; }
        public DbSet<topic> topics { get; set; }
        public DbSet<user_bookmark> user_bookmarks { get; set; }
        public DbSet<user_follower> user_followers { get; set; }
        public DbSet<user_following> user_following { get; set; }
        public DbSet<user_interest> user_interests { get; set; }
        public DbSet<user_location> user_locations { get; set; }
        public DbSet<user_post_like> user_post_likes { get; set; }
        public DbSet<user_post> user_posts { get; set; }
        public DbSet<user> users { get; set; }

        public virtual ObjectResult<getNearbyPosts_Result> getNearbyPosts(Nullable<decimal> longitude, Nullable<decimal> latitude, Nullable<int> distance_in_km)
        {
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(decimal));

            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(decimal));

            var distance_in_kmParameter = distance_in_km.HasValue ?
                new ObjectParameter("distance_in_km", distance_in_km) :
                new ObjectParameter("distance_in_km", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getNearbyPosts_Result>("getNearbyPosts", longitudeParameter, latitudeParameter, distance_in_kmParameter);
        }

    }
}
