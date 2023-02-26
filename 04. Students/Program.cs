int studentCount = int.Parse(Console.ReadLine());

List<Student> studentsList = new List<Student>();

while (studentCount > 0)
{
    string[] studentInfo = Console.ReadLine().Split();
    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    double grade = double.Parse(studentInfo[2]);

    Student student = new Student
    {
        FirstName = firstName,
        LastName = lastName,
        Grade = grade
    };
    studentsList.Add(student);

    studentCount--;
}

foreach (Student student in studentsList.OrderByDescending(x => x.Grade))
{
    Console.WriteLine(student);
}

class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public double Grade  { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:f2}";
    }
}
