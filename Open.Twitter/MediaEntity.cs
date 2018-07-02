using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class MediaEntity
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "id_str")]
        public string IdStr { get; set; }
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }
        [DataMember(Name = "media_url")]
        public string MediaUrl { get; set; }
        [DataMember(Name = "media_url_https")]
        public string MediaUrlHttps { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "sizes")]
        public Sizes Sizes { get; set; }
    }

    [DataContract]
    public class Sizes
    {
        [DataMember(Name = "medium")]
        public Size Medium { get; set; }
        [DataMember(Name = "thumb")]
        public Size Thumb { get; set; }
        [DataMember(Name = "small")]
        public Size Small { get; set; }
        [DataMember(Name = "large")]
        public Size Large { get; set; }
    }

    [DataContract]
    public class Size
    {
        [DataMember(Name = "w")]
        public int W { get; set; }
        [DataMember(Name = "h")]
        public int H { get; set; }
        [DataMember(Name = "resize")]
        public string Resize { get; set; }
    }
}
