using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class SearchResponse
    {
        [DataMember(Name = "statuses")]
        public Tweet[] Statuses { get; set; }
        [DataMember(Name = "search_metadata")]
        public SearchMetadata SearchMetadata { get; set; }
    }

    [DataContract]
    public class SearchMetadata
    {
        [DataMember(Name = "max_id")]
        public long MaxId { get; set; }
        [DataMember(Name = "max_id_str")]
        public string MaxIdStr { get; set; }
        [DataMember(Name = "since_id")]
        public long SinceId { get; set; }
        [DataMember(Name = "since_id_str")]
        public string SinceIdStr { get; set; }
        [DataMember(Name = "refresh_url")]
        public string RefreshUrl { get; set; }
        [DataMember(Name = "next_results")]
        public string NextResults { get; set; }
        [DataMember(Name = "count")]
        public long Count { get; set; }
        [DataMember(Name = "completed_in")]
        public double CompletedIn { get; set; }
        [DataMember(Name = "query")]
        public string Query { get; set; }
    }
}
