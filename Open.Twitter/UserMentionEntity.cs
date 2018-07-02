using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class UserMentionEntity
    {
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "id_str")]
        public string IdStr { get; set; }
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }
    }
}
