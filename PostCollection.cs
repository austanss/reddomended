using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reddomended
{
    internal class PostCollection
    {
        private PostCollection(FileStream file)
        {
            if (!file.CanRead)
                throw new FileLoadException("FileStream was unreadable.");

            StreamReader sr = new StreamReader(file);
            string fileContents = sr.ReadToEnd();

            string[] categoryBodies = fileContents.Split("===");
            List<PostCategory> postCategories = new List<PostCategory>();

            foreach (string categoryBody in categoryBodies)
            {
                if (categoryBody == "<XXXXX>")
                    break;

                PostCategory postCategory = new PostCategory();
                string[] trimmed = categoryBody.Split(">>>\r\n");
                postCategory.Name = trimmed[0];
                postCategory.Description = "A cool community";

                string[] postDetails = trimmed[1].Split("\n");
                List<Post> posts = new List<Post>();

                foreach (string postDetail in postDetails)
                {
                    if (postDetail == "---")
                        break;

                    Post post = new Post();

                    // Title - Body - Score - Date/Time
                    string[] details = postDetail.Split(",,,");

                    post.Title = details[0];
                    post.Body = details[1];
                    post.Score = Convert.ToInt32(details[2]);
                    post.TimeOfPost = DateTime.Parse(details[3]);

                    posts.Add(post);
                }

                postCategory.Posts = posts.ToArray();

                postCategories.Add(postCategory);
            }

            PostCategory benchmark = new PostCategory();
            benchmark.Name = "InternalBenchmark";
            benchmark.Description = "An internal benchmark for the sorting algorithm. Uses randomly generated data.";
            benchmark.Posts = new Post[1048576];

            Random rng = new Random();

            DateTime startDate = new DateTime(2011, 1, 1);

            for (int i = 0; i < benchmark.Posts.Length; i++)
            {
                benchmark.Posts[i] = new Post();

                benchmark.Posts[i].Score = rng.Next(500000);

                benchmark.Posts[i].TimeOfPost = startDate.AddDays(rng.Next((DateTime.Today - startDate).Days));

                benchmark.Posts[i].Title = rng.NextInt64().ToString();

                benchmark.Posts[i].Body = rng.NextInt64().ToString();
            }

            postCategories.Add(benchmark);

            Categories = postCategories.ToArray();

            file.Dispose();
        }

        /// <summary>
        /// A function to serialize a file for quick manipulation.
        /// </summary>
        /// <param name="file">A FileStream object pointing to the file.</param>
        /// <returns>The serialized file. Disposes the filestream upon return.</returns>
        /// <exception cref="ArgumentNullException">The FileStream was null and invalid.</exception>
        public static PostCollection Serialize(FileStream file)
        {
            if (file == null)
                throw new ArgumentNullException("FileStream at file was null.");

            return new PostCollection(file);
        }

        public PostCategory[] Categories { get; private set; }
    }
}
