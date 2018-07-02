using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "id_str")]
        public string IdStr { get; set; }
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
        [DataMember(Name = "profile_sidebar_fill_color")]
        public string ProfileSidebarFillColor { get; set; }
        [DataMember(Name = "profile_sidebar_border_color")]
        public string ProfileSidebarBorderColor { get; set; }
        [DataMember(Name = "profile_background_tile")]
        public bool ProfileBackgroundTile { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }
        [DataMember(Name = "follow_request_sent")]
        public bool FollowRequestSent { get; set; }
        [DataMember(Name = "profile_link_color")]
        public string ProfileLinkColor { get; set; }
        [DataMember(Name = "is_translator")]
        public bool IsTranslator { get; set; }
        [DataMember(Name = "entities")]
        public Entities Entities { get; set; }
        [DataMember(Name = "default_profile")]
        public bool DefaultProfile { get; set; }
        [DataMember(Name = "contributors_enabled")]
        public bool ContributorsEnabled { get; set; }
        [DataMember(Name = "favourites_count")]
        public string FavouritesCount { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "profile_image_url_https")]
        public string ProfileImageUrlHttps { get; set; }
        [DataMember(Name = "utc_offset")]
        public string UtcOffset { get; set; }
        [DataMember(Name = "profile_use_background_image")]
        public bool ProfileUseBackgroundImage { get; set; }
        [DataMember(Name = "listed_count")]
        public long ListedCount { get; set; }
        [DataMember(Name = "profile_text_color")]
        public string ProfileTextColor { get; set; }
        [DataMember(Name = "lang")]
        public string Lang { get; set; }
        [DataMember(Name = "followers_count")]
        public long FollowersCount { get; set; }
        [DataMember(Name = "protected")]
        public bool Protected { get; set; }
        [DataMember(Name = "notifications")]
        public bool Notifications { get; set; }
        [DataMember(Name = "profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlHttps { get; set; }
        [DataMember(Name = "profile_background_color")]
        public string ProfileBackgroundColor { get; set; }
        [DataMember(Name = "verified")]
        public bool Verified { get; set; }
        [DataMember(Name = "geo_enabled")]
        public bool GeoEnabled { get; set; }
        [DataMember(Name = "time_zone")]
        public string TimeZone { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "default_profile_image")]
        public bool DefaultProfileImage { get; set; }
        [DataMember(Name = "profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; set; }
        [DataMember(Name = "statuses_count")]
        public long StatusesCount { get; set; }
        [DataMember(Name = "friends_count")]
        public long FriendsCount { get; set; }
        [DataMember(Name = "following")]
        public bool Following { get; set; }
        [DataMember(Name = "show_all_inline_media")]
        public string ShowAllInlineMedia { get; set; }
    }
}
