using System;
using System.Runtime.Serialization;

namespace Open.Twitter
{
    public class TwitterException : Exception
    {
        public TwitterException()
        {
        }

        public TwitterException(TwitterErrors errors)
        {
            Errors = errors;
        }

        public TwitterException(Exception exc)
            : base(exc.Message, exc)
        {
        }

        public TwitterErrors Errors { get; private set; }
    }

    [DataContract]
    public class TwitterErrors
    {
        [DataMember(Name = "errors")]
        public TwitterError[] Errors { get; set; }

    }

    [DataContract]
    public class TwitterError
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
