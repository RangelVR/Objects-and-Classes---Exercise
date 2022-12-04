using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Articles_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> catalog = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                Article newArticle = new Article()
                {
                    Title = input[0],
                    Content = input[1],
                    Author = input[2],
                };

                catalog.Add(newArticle);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                catalog = catalog.OrderBy(x => x.Title).ToList();
            }
            else if (command == "content")
            {
                catalog = catalog.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                catalog = catalog.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, catalog));
        }

    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            //return $"{Title} - {Content}: {Author}";
            StringBuilder sb = new StringBuilder($"{Title} - {Content}: {Author}");
            return sb.ToString().TrimEnd();
        }
    }
}
