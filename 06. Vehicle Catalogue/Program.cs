using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Vehicle> catalog = new List<Vehicle>();

            while (true)
            {
                string[] vehicle = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (vehicle[0] == "End")
                {
                    break;
                }

                string type = vehicle[0];
                string model = vehicle[1];
                string color = vehicle[2];
                double power = double.Parse(vehicle[3]);

                Vehicle newVehicle = new Vehicle(type, model, color, power);

                catalog.Add(newVehicle);

            }

            while (true)
            {
                string modelOf = Console.ReadLine();

                if (modelOf == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(catalog.Find(x => x.Model == modelOf));
            }

            List<Vehicle> onlyCars = catalog.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = catalog.Where(x => x.Type == "truck").ToList();
            double totalHpCars = 0;
            double totalHpTrucks = 0;

            foreach (Vehicle car in onlyCars)
            {
                totalHpCars += car.HorsePower;
            }

            foreach (Vehicle truck in onlyTrucks)
            {
                totalHpTrucks += truck.HorsePower;
            }

            double averageHpCars = totalHpCars / onlyCars.Count;
            double averageHpTrucs = totalHpTrucks / onlyTrucks.Count;

            if (onlyCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageHpCars:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageHpTrucs:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }

        
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, double power)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = power;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            string print = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                $"Model: {this.Model}{Environment.NewLine}" +
                $"Color: {this.Color}{Environment.NewLine}" +
                $"Horsepower: {this.HorsePower}";

            return print;
        }
        
    }
}
