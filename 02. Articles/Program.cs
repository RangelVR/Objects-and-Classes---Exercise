using System;
using System.Linq;
using System.Text;

namespace Articles
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
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
                string[] comandArr = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                if (comandArr[0] == "Edit")
                {
                    newArticle.Edit(comandArr[1]);
                }
                else if (comandArr[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(comandArr[1]);
                }
                else if (comandArr[0] == "Rename")
                {
                    newArticle.Rename(comandArr[1]);
                }
                counter++;
            }

            Console.WriteLine(newArticle);
        }

       
    }

    class Article
    {
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

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            //StringBuilder sb = new StringBuilder($"{Title} - {Content}: {Author}");
            //return sb.ToString().TrimEnd();

            return $"{Title} - {Content}: {Author}";
        }

    }
}
