string command = Console.ReadLine();

List<Person> personsList = new List<Person>();

while (command != "End")
{
    string[] commInfo = command.Split();

    string name = commInfo[0]; 
    string iD = commInfo[1];
    int age = int.Parse(commInfo[2]);

    Person person = new Person(name, iD, age);
    personsList.Add(person);

    foreach (Person currPerson in personsList)
    {
        if (currPerson.ID == iD)
        {
            currPerson.Name = name;
            currPerson.Age = age;
            break;
        }
    }

    command = Console.ReadLine();
}

foreach (Person currPerson in personsList.OrderBy(x => x.Age))
{
    Console.WriteLine(currPerson);
}

class Person
{
    public Person(string name, string iD, int age)
    {
        Name = name;
        ID = iD;
        Age = age;
    }

    public string Name { get; set; }

    public string ID { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        string output = $"{Name} with ID: {ID} is {Age} years old.";
        return output;
    }
}
