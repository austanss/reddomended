
using reddomended;

const string VERSION = "1.0.0";

Console.WriteLine($"reddomended v{VERSION}\n");

FileStream fs = File.OpenRead("SampleReddit.txt");

SerializedFile reddit = SerializedFile.Serialize(fs);

Console.WriteLine("Categories:");

foreach (PostCategory category in reddit.Categories)
    Console.WriteLine($"\t/{category.Name}");

choose:

string choice = "";

Console.Write("\nChoose category: /");

choice = Console.ReadLine();

PostCategory chosen = null;

foreach (PostCategory category in reddit.Categories)
    if (category.Name == choice)
        chosen = category;

if (chosen == null)
    goto choose;

SortingAlgorithm sorter = new SortingAlgorithm(chosen);

Post[] posts = sorter.SortByNew();

foreach (Post post in posts)
    Console.WriteLine($"{post.Title} ^ {post.Score} ({post.TimeOfPost})\n\t{post.Body}\n");
