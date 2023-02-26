
int numArticles = int.Parse(Console.ReadLine());

List<Article> articleList = new List<Article>();

while (numArticles > 0)
{
    string[] articleInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string title = articleInput[0];
    string content = articleInput[1];
    string author = articleInput[2];

    Article article = new Article(title, content, author);
    articleList.Add(article);

    numArticles--;
}

string command = Console.ReadLine();

if (command == "title")
{
    articleList = articleList.OrderBy(x => x.Title).ToList();
}
else if (command == "content")
{
    articleList = articleList.OrderBy(x => x.Content).ToList();
}
else if (command == "author")
{
    articleList = articleList.OrderBy(x => x.Author).ToList();
}

foreach (Article article in articleList)
{
    Console.WriteLine(article);
}


class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
