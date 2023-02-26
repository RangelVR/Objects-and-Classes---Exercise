using System.Runtime.CompilerServices;
using System.Text;

string info = Console.ReadLine();

List<Vehicle> carsList = new List<Vehicle>();
List<Vehicle> truckLlist = new List<Vehicle>();

while (info != "End")
{
    string[] infoArr = info.Split();

    string type = infoArr[0];
    string model = infoArr[1];
    string color = infoArr[2];
    double power = double.Parse(infoArr[3]);

    if (type == "car")
    {
        Vehicle car = new Vehicle(type, model, color, power);
        carsList.Add(car);
    }
    else
    {
        Vehicle truck = new Vehicle(type, model, color, power);
        truckLlist.Add(truck);
    }

    info = Console.ReadLine();
}

string make = Console.ReadLine();

while (make != "Close the Catalogue")
{
    if (carsList.Any(x => x.Make.Contains(make)))
    {
        foreach (Vehicle car in carsList)
        {
            if (car.Make == make)
            {
                Console.WriteLine(car);
            }
        }
    }
    else
    {
        foreach (Vehicle truck in truckLlist)
        {
            if (truck.Make == make)
            {
                Console.WriteLine(truck);
            }
        }
    }

    make = Console.ReadLine();
}

if (carsList.Count > 0)
{
    double averageCarsPower = carsList.Average(x => x.HorsePower);
    Console.WriteLine($"Cars have average horsepower of: {averageCarsPower:f2}.");
}
else
{
    Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
}

if (truckLlist.Count > 0)
{
    double averageTruckPower = truckLlist.Average(x => x.HorsePower);
    Console.WriteLine($"Trucks have average horsepower of: {averageTruckPower:f2}.");
}
else
{
    Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
}



class Vehicle
{
    public Vehicle(string type, string make, string color, double power)
    {
        Type = type;
        Make = make;
        Color = color;
        HorsePower = power;
    }

    public string Type { get; set; }

    public string Make { get; set; }

    public string Color { get; set; }

    public double HorsePower { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (Type == "car")
        {
            Type = "Car";
        }
        else
        {
            Type = "Truck";
        }

        sb.AppendLine($"Type: {Type}");
        sb.AppendLine($"Model: {Make}");
        sb.AppendLine($"Color: {Color}");
        sb.AppendLine($"Horsepower: {HorsePower}");

        return sb.ToString().TrimEnd(); 
    }
}

