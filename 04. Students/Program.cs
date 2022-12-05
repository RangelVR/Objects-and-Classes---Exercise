using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;

            LastName = lastName;

            Grade = grade;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            var listOfStudents = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] student = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstName = student[0];
                string lastName = student[1];
                double grade = double.Parse(student[2]);

                Student newStudent = new Student(firstName, lastName, grade);

                listOfStudents.Add(newStudent);
            }

            listOfStudents = listOfStudents.OrderByDescending(x => x.Grade)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, listOfStudents));
        }
    }
}
