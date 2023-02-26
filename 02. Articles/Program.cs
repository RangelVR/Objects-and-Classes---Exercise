
string[] articleInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

string title = articleInput[0];
string content = articleInput[1];
string author = articleInput[2];

Article article = new Article(title, content, author);

int numOfCommands = int.Parse(Console.ReadLine());

while (numOfCommands > 0)
{
    string[] commandInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

    if (commandInfo[0] == "Edit")
    {
        string newContent = commandInfo[1];
        article.Edit(newContent);
    }
    else if (commandInfo[0] == "ChangeAuthor")
    {
        string newAuthor = commandInfo[1];
        article.ChangeAuthor(newAuthor);
    }
    else if (commandInfo[0] == "Rename")
    {
        string newTitle = commandInfo[1];
        article.Rename(newTitle);
    }

    numOfCommands--;
}

Console.WriteLine(article);

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

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle; 
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
