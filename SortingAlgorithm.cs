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

        public static List<T> shiftFrom<T>(List<T> list, int i)
        {
            list.Add(list[list.Count-1]);

            for (int j = list.Count - 1; j >= i; j--)
                list[j] = list[j-1];

            list[i] = default;

            return list;
        } 

        public Post[] SortByNew()
        {
            List<Post> posts = new List<Post>();

            posts.Add(Category.Posts[0]);

            for (int i = 1, j = 0; i < Category.Posts.Length; i++)
            {
                Post post = Category.Posts[i];
                
                if ((posts[i-j-1].TimeOfPost - post.TimeOfPost).TotalMilliseconds < 0)
                {
                    if (j==0) posts.Add(post);
                    posts[i-j] = posts[i-(++j)];
                    posts[i-j] = post;
                    if (i - j == 0)
                    {
                        i++;
                        j = 0;
                    }
                    i--;
                }
                else
                {
                    if (j==0) posts.Add(post);
                    j = 0;
                }
            }

            return posts.ToArray();
        }

        public PostCategory Category { get; private set; }
    }
}
