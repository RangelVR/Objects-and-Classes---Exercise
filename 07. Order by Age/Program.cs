using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            string print = $"{Name} with ID: {ID} is {Age} years old.";

            return print;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            while (true)
            {
                string[] personArgs = Console.ReadLine().Split().ToArray();

                if (personArgs[0] == "End")
                {
                    break;
                }

                string name = personArgs[0];
                string id = personArgs[1];
                int age = int.Parse(personArgs[2]);

                Person newPerson = new Person(name, id, age);
                if (list.Any(x => x.ID == id))
                {
                    foreach (var person in list)
                    {
                        if (person.ID == id)
                        {
                            person.Name = name;
                            person.Age = age;
                        }
                    }
                    continue;
                }
                list.Add(newPerson);
            }

            Console.WriteLine(string.Join(Environment.NewLine, list.OrderBy(x => x.Age)));
        }
    }
}