using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class SymbolEntity
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }
    }
}
