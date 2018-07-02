using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class ItemsResponse
    {

    }

    [DataContract]
    public class Item
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "user")]
        public Settings User { get; set; }
    }
}
