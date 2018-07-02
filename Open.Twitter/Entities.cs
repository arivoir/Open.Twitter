using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class Entities
    {
        [DataMember(Name = "media")]
        public MediaEntity[] Media { get; set; }
        [DataMember(Name = "urls")]
        public UrlEntity[] Urls { get; set; }
        [DataMember(Name = "user_mentions")]
        public UserMentionEntity[] UserMentions { get; set; }
        [DataMember(Name = "hashtags")]
        public HashtagEntity[] Hashtags { get; set; }
        [DataMember(Name = "symbols")]
        public SymbolEntity[] Symbols { get; set; }
    }
}