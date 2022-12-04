using System;
using System.Linq;
using System.Text;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            Article newArticle = new Article() 
            {
                Title = input[0],
                Content = input[1],
                Author = input[2]
            };

            while (counter != n)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                if (command[0] == "Edit")
                {
                    newArticle.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    newArticle.Rename(command[1]);
                }
                counter++;
            }
            Console.WriteLine(newArticle);
        } 
        
    }

    class Article
    {
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
            //return $"{Title} - {Content}: {Author}";
            StringBuilder sb = new StringBuilder($"{Title} - {Content}: {Author}");
            return sb.ToString().TrimEnd();
        }
    }
}
