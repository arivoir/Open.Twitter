using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class Tweet
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "id_str")]
        public string IdStr { get; set; }
        [DataMember(Name = "coordinates")]
        public string Coordinates { get; set; }
        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }
        [DataMember(Name = "truncated")]
        public bool Truncated { get; set; }
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "entities")]
        public Entities Entities { get; set; }
        [DataMember(Name = "in_reply_to_user_id")]
        public long? InReplyToUserId { get; set; }
        [DataMember(Name = "in_reply_to_user_id_str")]
        public string InReplyToUserIdStr { get; set; }
        [DataMember(Name = "contributors")]
        public string Contributors { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "retweet_count")]
        public int RetweetCount { get; set; }
        [DataMember(Name = "in_reply_to_status_id")]
        public long? InReplyToStatusId { get; set; }
        [DataMember(Name = "in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr { get; set; }
        [DataMember(Name = "geo")]
        public string Geo { get; set; }
        [DataMember(Name = "retweeted")]
        public bool Retweeted { get; set; }
        [DataMember(Name = "possibly_sensitive")]
        public bool PossiblySensitive { get; set; }
        [DataMember(Name = "place")]
        public string Place { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
        [DataMember(Name = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
    }
}
