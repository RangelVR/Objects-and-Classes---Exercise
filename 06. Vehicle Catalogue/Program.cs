using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    class Vehicles
    {
        public Vehicles(string type, string model, string color, double power)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = power;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            string print = $"Type: {(Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                $"Model: {Model}{Environment.NewLine}" +
                $"Color: {Color}{Environment.NewLine}" +
                $"Horsepower: {HorsePower}";

            return print;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicles> catalog = new List<Vehicles>();

            while (true)
            {
                string[] arr = Console.ReadLine().Split().ToArray();

                if (arr[0] == "End")
                {
                    break;
                }
                
                string type = arr[0];
                string model = arr[1];
                string color = arr[2];
                double power = double.Parse(arr[3]);

                Vehicles newVehicle = new Vehicles(type, model, color, power);

                catalog.Add(newVehicle);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Close the Catalogue")
                {
                    break;
                }
                Console.WriteLine(catalog.Find(x => x.Model == command));
            }

            List<Vehicles> cars = catalog.Where(x => x.Type == "car").ToList();
            List<Vehicles> trucks = catalog.Where(x => x.Type == "truck").ToList();

            double hpCars = 0;
            double hpTrucks = 0;
            foreach (var car in cars)
            {
                hpCars += car.HorsePower;
            }
            foreach (var truck in trucks)
            {
                hpTrucks += truck.HorsePower;
            }

            if (cars.Count > 0)
            {
                
                Console.WriteLine($"Cars have average horsepower of: {(hpCars / cars.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(hpTrucks / trucks.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
-----------------------------------------------------------------------------------------------------------
    
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    class Vehicles
    {
        public Vehicles(string type, string model, string color, double horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            string print = $"Type: {this.Type}{Environment.NewLine}" +
                $"Model: {this.Model}{Environment.NewLine}" +
                $"Color: {this.Color}{Environment.NewLine}" +
                $"Horsepower: {this.HorsePower}";

            return print;
        }
    }

    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Vehicles>();
            Trucks = new List<Vehicles>();
        }
        public List<Vehicles> Cars { get; set; }
        public List<Vehicles> Trucks { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string command;

            Catalog catalog = new Catalog();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commArr = command.Split().ToArray();
                string type = commArr[0];
                string model = commArr[1];
                string color = commArr[2];
                double horsePower = double.Parse(commArr[3]);

                if (type == "car")
                {
                    type = "Car";
                    Vehicles newCar = new Vehicles(type, model, color, horsePower);
                    catalog.Cars.Add(newCar);
                }
                else 
                {
                    type = "Truck";
                    Vehicles newTruck = new Vehicles(type, model, color, horsePower);
                    catalog.Trucks.Add(newTruck);
                }
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var car in catalog.Cars)
                {
                    if (command == car.Model)
                    {
                        Console.WriteLine(car);
                    }
                }
                foreach (var truck in catalog.Trucks)
                {
                    if (command == truck.Model)
                    {
                        Console.WriteLine(truck);
                    }
                }
            }
            double totalHpCars = 0;
            double totalHpTrucks = 0;

            foreach (var car in catalog.Cars)
            {
                 totalHpCars += car.HorsePower;
            }
            foreach (var truck in catalog.Trucks)
            {
                 totalHpTrucks += truck.HorsePower;
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {totalHpCars / catalog.Cars.Count:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(totalHpTrucks / catalog.Trucks.Count):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
