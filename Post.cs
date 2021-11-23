using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reddomended
{
    internal class Post
    {
        public Post()
        {
            Title = new string("An interesting title");
            Body = new string("An interesting body.");
            Score = 0;
        }

        public string Title { get; internal set; }
        public string Body { get; internal set; }
        public int Score { get; internal set; }
        public DateTime TimeOfPost { get; internal set; }

        public double UpvotesPerHour { get { return Score / ((DateTime.Now - TimeOfPost).TotalSeconds / 60 / 60); } }
    }
}
