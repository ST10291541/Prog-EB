using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class Influencer
    {
        public string Username { get; set; }
        public int Followers { get; set; }
        public DateTime Started { get; set; }
        public string RecentPost { get; set; }

        public Influencer(string username, int followers, DateTime started, string recentPost)
        {
            Username = username;
            Followers = followers;
            Started = started;
            RecentPost = recentPost;
        }

        public override string ToString()
        {
            return $"Username: {Username}, Followers: {Followers}, " +
                   $"Started: {Started.ToShortDateString()}, Recent Post: {RecentPost}";
        }
    }
}
