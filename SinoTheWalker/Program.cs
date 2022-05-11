using System;
using System.Globalization;

namespace SinoTheWalker
{
    internal class Program
    {
        static void Main()
        {
            DateTime leaveTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            //1 day = 86400
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int stepTime = int.Parse(Console.ReadLine()) % 86400;

            double stepsInSec = (steps * stepTime);
            DateTime arrivalTime = leaveTime.AddSeconds(stepsInSec);

            Console.WriteLine($"Time Arrival: {arrivalTime:HH:mm:ss}");
        }
    }
}
