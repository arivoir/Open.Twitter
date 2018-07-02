using System.Runtime.Serialization;

namespace Open.Twitter
{
    [DataContract]
    public class Settings
    {
        [DataMember(Name = "time_zone")]
        public TimeZone TimeZone { get; set; }
        [DataMember(Name = "protected")]
        public bool Protected { get; set; }
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
        [DataMember(Name = "always_use_https")]
        public string AlwaysUseHttps { get; set; }
        [DataMember(Name = "use_cookie_personalization")]
        public string UseCookiePersonalization { get; set; }
        [DataMember(Name = "sleep_time")]
        public SleepTime SleepTime { get; set; }
        [DataMember(Name = "geo_enabled")]
        public bool GeoEnabled { get; set; }
        [DataMember(Name = "language")]
        public string Language { get; set; }
        [DataMember(Name = "discoverable_by_email")]
        public bool DiscoverableByEmail { get; set; }
        [DataMember(Name = "discoverable_by_mobile_phone")]
        public bool DiscoverableByMobilePhone { get; set; }
        [DataMember(Name = "display_sensitive_media")]
        public bool DisplaySensitiveMedia { get; set; }
    }

    [DataContract]
    public class TimeZone
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "utc_offset")]
        public int? UtcOffset { get; set; }
        [DataMember(Name = "tzinfo_name")]
        public string TzinfoName { get; set; }
    }
    [DataContract]
    public class SleepTime
    {
        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "end_time")]
        public string EndTime { get; set; }
        [DataMember(Name = "start_time")]
        public string StartTime { get; set; }
    }

}
