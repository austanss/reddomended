
using reddomended;

const string VERSION = "1.1.0";

Console.WriteLine($"reddomended v{VERSION}\n");

FileStream fs = File.OpenRead("SampleCollection.txt");

PostCollection collection = PostCollection.Serialize(fs);

Console.WriteLine("Categories:");

foreach (PostCategory category in collection.Categories)
    Console.WriteLine($"\t/{category.Name}");

choose:

string choice = "";

Console.Write("\nChoose category: /");

choice = Console.ReadLine();

Console.WriteLine("\n\tHot - 1\n\tNew - 2\n\tTop - 3");

Console.Write("\nChoose sorting: ");

int sort = Console.Read();

sort -= 48;

PostCategory chosen = null;

foreach (PostCategory category in collection.Categories)
    if (category.Name == choice)
        chosen = category;

if (chosen == null)
    goto choose;

SortingAlgorithm sorter = new SortingAlgorithm(chosen);

Post[] posts;

switch (sort)
{
    case 1:
        posts = sorter.SortByHot();
        break;

    case 2:
        posts = sorter.SortByNew();
        break;

    case 3:
        posts = sorter.SortByTop();
        break;

    default:
        posts = sorter.SortByHot();
        break;
}

foreach (Post post in posts)
    Console.WriteLine($"{post.Title} ^ {post.Score} ({post.TimeOfPost})\n\t{post.Body}\n");
