﻿using System;
using System.Collections.Generic;

namespace Advertisement_Message
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phrases = {"Excellent product.",
                "Such a great product.",
                "I always use that product.", "" +
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            string[] events = {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"};

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();

            for (int i = 1; i <= n; i++)
            {
                string phrase = phrases[random.Next(0, phrases.Length)];
                string @event = events[random.Next(0, events.Length)];
                string author = authors[random.Next(0, authors.Length)];
                string city = cities[random.Next(0, cities.Length)];

                Console.WriteLine("{0} {1} {2} - {3}", phrase, @event, author, city);
            }



        }
    }
}
