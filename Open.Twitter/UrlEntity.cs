using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class UrlEntity
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; set; }
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }
    }
}
