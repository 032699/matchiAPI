 

namespace MatchiDataProvider
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_post_like
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int user_post_like_id { get; set; }
        public Nullable<int> user_post_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<long> poster_user_id { get; set; }
        public string post_category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string images_url { get; set; }
        public Nullable<int> like_count { get; set; }
        public Nullable<int> is_reported { get; set; }
        public Nullable<System.DateTime> date_posted { get; set; }
        public string user_avatar_url { get; set; }
        public string user_name { get; set; }
        public string item_price { get; set; }
        public string user_full_name { get; set; }
        public string map_address { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public string post_category_img_url { get; set; }
        public Nullable<int> post_category_id { get; set; }
        public Nullable<int> post_type_id { get; set; }
        public Nullable<int> topic_id { get; set; }
    }
}
