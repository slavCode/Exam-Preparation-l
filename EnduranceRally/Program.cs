using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceRally
{
    internal class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            decimal[] zones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();
            decimal[] checkpoints = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .OrderBy(c => c)
                .ToArray();

            List<Driver> drivers = new List<Driver>();
            foreach (string name in names)
            {
                Driver driver = new Driver();
                driver.Name = name;
                driver.GetStartingFuel();

                for (int i = 0; i < zones.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        driver.Fuel += zones[i];
                    }
                    else driver.Fuel -= zones[i];

                    if (driver.Fuel < 1)
                    {
                        driver.ZoneFinished = i;
                        break;
                    }
                }

                drivers.Add(driver);
            }

            foreach (var driver in drivers)
            {
                if (driver.Fuel < 1)
                {
                    Console.WriteLine($"{driver.Name} - reached {driver.ZoneFinished}");
                }
                else
                {
                    Console.WriteLine($"{driver.Name} - fuel left {driver.Fuel:f2}");
                }
            }
        }

        class Driver
        {
            public string Name { get; set; }
            public decimal Fuel { get; set; }
            public int ZoneFinished { get; set; }
            public void GetStartingFuel()
            {
                Fuel = Name[0];
            }
        }
    }
}
