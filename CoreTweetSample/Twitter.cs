using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTweet;
using CoreTweet.Core;
using System.Configuration;

namespace CoreTweetSample
{
    public class Twitter
    {
        private string _apiKey = ConfigurationManager.AppSettings["TWITTER_API_KEY"];
        private string _apiSecret = ConfigurationManager.AppSettings["TWITTER_API_SECRET"];
        private string _accessToken = ConfigurationManager.AppSettings["TWITTER_ACCESS_TOKEN"];
        private string _accessSecret = ConfigurationManager.AppSettings["TWITTER_ACCESS_SECRET"];

        private Tokens _tokens;

        public Twitter()
        {
            _tokens = CoreTweet.Tokens.Create(_apiKey, _apiSecret, _accessToken, _accessSecret);
        }

        public long Tweet(string tweetText)
        {
            var response = _tokens.Statuses.UpdateAsync(tweetText);
            return response.Id;
        }

        public long Reply(string tweetText, long? replyToStatusId)
        {
            var response = _tokens.Statuses.UpdateAsync(status => tweetText, in_reply_to_status_id => replyToStatusId);
            return response.Id;
        }

        public long Retweet(long id)
        {
            var response = _tokens.Statuses.Retweet(id);
            return response.Id;
        }

        public long QuoteTweet(string tweetText, string screen_name, long statusId)
        {
            var url = string.Format("https://twitter.com/{0}/status/{1}", screen_name, statusId);
            var response = _tokens.Statuses.UpdateAsync(status => tweetText + " " + url);
            return response.Id;
        }

        public long QuoteTweet(string tweetText, string url)
        {
            var response = _tokens.Statuses.UpdateAsync(tweetText + " " + url);
            return response.Id;
        }

        public long Favorite(long tweetId)
        {
            var response = _tokens.Favorites.CreateAsync(tweetId);
            return response.Id;
        }
    }
}
