using Open.IO;
using Open.Net.Http;
using Open.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Open.Twitter
{
    public class TwitterClient : OAuthClient
    {
        #region ** fields

        private static string _requestTokenUri = "https://api.twitter.com/oauth/request_token";
        private static string _authorizeUri = "https://api.twitter.com/oauth/authorize";
        private static string _accessTokenUri = "https://api.twitter.com/oauth/access_token";
        private string ApiServiceUri = "https://api.twitter.com/1.1/";
        private string _accessToken = null;
        private string ConsumerKey;
        private string ConsumerToken;
        private string AccessToken;
        private string AccessTokenSecret;

        public TwitterClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public TwitterClient(string ConsumerKey, string ConsumerToken, string AccessToken, string AccessTokenSecret)
        {
            // TODO: Complete member initialization
            this.ConsumerKey = ConsumerKey;
            this.ConsumerToken = ConsumerToken;
            this.AccessToken = AccessToken;
            this.AccessTokenSecret = AccessTokenSecret;
        }

        #endregion

        #region ** authentication

        public static async Task<OAuthToken> GetRequestTokenAsync(string oauthConsumerKey, string oauthConsumerSecret, string callbackUrl = "oob")
        {
            return await OAuthClient.GetRequestTokenAsync(_requestTokenUri, oauthConsumerKey, oauthConsumerSecret, callbackUrl);
        }

        public static string GetAuthorizeUrl(string oauthConsumerKey, string oauthConsumerSecret, string requestToken)
        {
            return OAuthClient.GetAuthorizeUrl(_authorizeUri, oauthConsumerKey, oauthConsumerSecret, requestToken);
        }

        public static async Task<OAuthToken> GetAccessTokenAsync(string oauthConsumerKey, string oauthConsumerSecret, string oauthToken, string oauthTokenSecret, string oauthVerifier)
        {
            return await OAuthClient.GetAccessTokenAsync(_accessTokenUri, oauthConsumerKey, oauthConsumerSecret, oauthToken, oauthTokenSecret, oauthVerifier);
        }


        #endregion

        #region ** public methods

        public async Task<User> GetUserAsync(CancellationToken cancellationToken)
        {
            var uri = BuildApiUri("account/verify_credentials");
            var client = CreateClient();
            var response = await client.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<User>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Settings> GetSettingsAsync(CancellationToken cancellationToken)
        {
            var uri = BuildApiUri("account/settings");
            var client = CreateClient();
            var response = await client.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Settings>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Tweet[]> GetUserTimelineAsync(int? count, long? maxId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>();
            if (count.HasValue)
                parameters["count"] = count.ToString();
            if (maxId.HasValue)
                parameters["max_id"] = maxId.ToString();
            var uri = BuildApiUri("statuses/user_timeline", parameters: parameters);
            var client = CreateClient();
            var response = await client.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Tweet[]>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Tweet[]> GetMentionsAsync(string tweetId, int? count = null, long? maxId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>();
            if (count.HasValue)
                parameters["count"] = count.ToString();
            if (maxId.HasValue)
                parameters["max_id"] = maxId.ToString();
            parameters["since_id"] = tweetId;
            var uri = BuildApiUri("statuses/mentions_timeline", parameters: parameters);
            var client = CreateClient();
            var response = await client.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Tweet[]>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Tweet> AddTweetAsync(string status, string inReplyToStatusId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>();
            parameters["status"] = status;
            if (!string.IsNullOrWhiteSpace(inReplyToStatusId))
                parameters["in_reply_to_status_id"] = inReplyToStatusId;
            var uri = BuildApiUri("statuses/update", mode: "POST", parameters: parameters);
            var client = CreateClient();
            var response = await client.PostAsync(uri, new StreamContent(new MemoryStream()), cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Tweet>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Tweet> AddTweetWithMediaAsync(string status, Stream fileStream, string inReplyToStatusId, IProgress<StreamProgress> progress, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(inReplyToStatusId))
                parameters["in_reply_to_status_id"] = inReplyToStatusId;
            var uri = BuildApiUri("statuses/update_with_media", mode: "POST", parameters: parameters);
            var client = CreateClient();
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(status), "status");
            content.Add(new StreamedContent(fileStream, progress, cancellationToken), "media[]", "media.png");//"application/octet-stream"
            var response = await client.PostAsync(uri, content, cancellationToken);//.AsTask(cancellationToken, progress);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Tweet>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Stream> DownloadFileAsync(Uri url, CancellationToken cancellationToken)
        {
            var client = CreateClient();
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return new StreamWithLength(await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentLength);
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Tweet> DeleteTweet(string tweetId, CancellationToken cancellationToken)
        {
            var uri = BuildApiUri("statuses/destroy/" + tweetId, mode: "POST");
            var client = CreateClient();
            var response = await client.PostAsync(uri, new StreamContent(new MemoryStream()), cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Tweet>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<SearchResponse> SearchAsync(string q, int? count = null, long? maxId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>();
            parameters["q"] = q;
            //parameters["include_entities"] = "1";
            if (count.HasValue)
                parameters["count"] = count.ToString();
            if (maxId.HasValue)
                parameters["max_id"] = maxId.ToString();
            var uri = BuildApiUri("search/tweets", parameters: parameters);
            var client = CreateClient();
            var response = await client.GetAsync(uri, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<SearchResponse>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        #endregion

        #region ** private stuff

        private Uri BuildApiUri(string path, string mode = "GET", Dictionary<string, string> parameters = null)
        {
            return new Uri(OAuthClient.CreateOAuthUrl(ApiServiceUri + path + ".json", ConsumerKey, ConsumerToken, AccessToken, AccessTokenSecret, mode: mode, parameters: parameters));
        }

        private static HttpClient CreateClient()
        {
            var client = new HttpClient(HttpMessageHandlerFactory.Default.GetHttpMessageHandler(needsGZipDecompression:true));
            client.Timeout = Timeout.InfiniteTimeSpan;
            return client;
        }

        private async Task<Exception> ProcessException(HttpContent content)
        {
            var error = await content.ReadJsonAsync<TwitterErrors>();
            return new TwitterException(error);
        }

        #endregion
    }
}
