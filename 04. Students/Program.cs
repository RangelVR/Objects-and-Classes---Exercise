using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            List<Student> listOfStudents = new List<Student>();

            while (counter != n)
            {
                string[] currStudent = Console.ReadLine().Split().ToArray();

                Student newStudent = new Student() 
                {
                    FirstName = currStudent[0],
                    SecondName = currStudent[1],
                    Grade = double.Parse(currStudent[2])
                };
                listOfStudents.Add(newStudent);
                counter++;
            }

            listOfStudents = listOfStudents.OrderByDescending(x => x.Grade).ToList();

            foreach (Student student in listOfStudents)
            {
                Console.WriteLine(student);
            }
        } 
        
    }

    class Student 
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }
    
}
