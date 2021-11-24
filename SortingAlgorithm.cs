using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reddomended
{
    internal class SortingAlgorithm
    {
        public SortingAlgorithm(PostCategory category)
        {
            if (category == null)
                throw new ArgumentNullException("Category at category was null.");

            Category = category;
        }

        public Post[] SortByNew()
        {
            Post[] posts = new Post[Category.Posts.Length];

            posts[0] = Category.Posts[0];

            for (int i=1, j=0; i < Category.Posts.Length; i++)
            {
                Post post = Category.Posts[i];

                if ((posts[i-j-1].TimeOfPost - post.TimeOfPost).TotalMilliseconds < 0)
                {
                    if (j==0) posts[i] = post;
                    posts[i-j] = posts[i-(++j)];
                    posts[i-j] = post;
                    if (i-j == 0)
                    {
                        i++;
                        j=0;
                    }
                    i--;
                }
                else
                {
                    if (j==0) posts[i] = post;
                    j=0;
                }
            }

            return posts;
        }

        public Post[] SortByHot()
        {
            Post[] posts = new Post[Category.Posts.Length];

            posts[0] = Category.Posts[0];

            for (int i=1, j=0; i < Category.Posts.Length; i++)
            {
                Post post = Category.Posts[i];

                if ((posts[i-j-1].UpvotesPerHour - post.UpvotesPerHour) < 0)
                {
                    if (j==0) posts[i] = post;
                    posts[i-j] = posts[i-(++j)];
                    posts[i-j] = post;
                    if (i-j == 0)
                    {
                        i++;
                        j=0;
                    }
                    i--;
                }
                else
                {
                    if (j==0) posts[i] = post;
                    j = 0;
                }
            }

            return posts;
        }

        public Post[] SortByTop()
        {
            Post[] posts = new Post[Category.Posts.Length];

            posts[0] = Category.Posts[0];

            for (int i=1, j=0; i < Category.Posts.Length; i++)
            {
                Post post = Category.Posts[i];

                if ((posts[i-j-1].Score - post.Score) < 0)
                {
                    if (j==0) posts[i] = post;
                    posts[i-j] = posts[i - (++j)];
                    posts[i-j] = post;
                    if (i-j == 0)
                    {
                        i++;
                        j=0;
                    }
                    i--;
                }
                else
                {
                    if (j==0) posts[i] = post;
                    j=0;
                }
            }

            return posts;
        }

        public PostCategory Category { get; private set; }
    }
}
