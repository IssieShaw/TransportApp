
namespace TransportApp.Transport
{
    public static class TransportCalculator
    {
        public static void CalculateAndDisplayTotals(List<Boat> boats,
                                                     List<Car> cars,
                                                     List<Van> vans)
        {
            int totalCars = cars.Count;
            int totalVans = vans.Count;
            int totalBoats = boats.Count;
            int totalTransport = totalBoats + totalCars + totalVans;

            // LINQ with query syntax + LINQ with Lambda
            decimal totalValueBoats = (decimal)(from boat in boats
                                                select boat.Value).Sum();
            decimal totalValueCars = (decimal)cars.Sum(c => c.Value);
            decimal totalValueVans = (decimal)vans.Sum(v => v.Value);
            decimal totalValueAll = totalValueBoats + totalValueCars + totalValueVans;

            string formatTotalValueBoats = totalValueBoats.ToString("C");
            string formatTotalValueCars = totalValueCars.ToString("C");
            string formatTotalValueVans = totalValueVans.ToString("C");
            string formatTotalValueAll = totalValueAll.ToString("C");

            Console.WriteLine("__Transport Quantitites__");
            Console.WriteLine($"Total number of boats: {totalBoats}");
            Console.WriteLine($"Total number of cars: {totalCars}");
            Console.WriteLine($"Total number of vans: {totalVans}");
            Console.WriteLine($"Total number of all transport: {totalTransport}");
            Console.WriteLine("\n__Transport Total Values__");
            Console.WriteLine($"Total value of boats: {formatTotalValueBoats}");
            Console.WriteLine($"Total value of cars: {formatTotalValueCars}");
            Console.WriteLine($"Total value of vans: {formatTotalValueVans}");
            Console.WriteLine($"Total value of all transport: {formatTotalValueAll}");
        }

        public static void MinMaxValues(List<Boat> boats,
                                        List<Car> cars,
                                        List<Van> vans)
        {
            // Displaying minimum and maximum values
            Console.WriteLine("\n__Minimum and Maximum Values__");
            HandleMinMaxValues(boats, "Boat");
            HandleMinMaxValues(cars, "Car");
            HandleMinMaxValues(vans, "Van");
        }

        public static void HandleMinMaxValues<T>(List<T> vehiclesList,
                                                 string transportTypeName) where T : IVehicle
        {
            // Using LINQ to find min and max values
            decimal minValue = vehiclesList.Min(i => i.Value);
            decimal maxValue = vehiclesList.Max(i => i.Value);

            Console.WriteLine($"_{transportTypeName}_");
            Console.WriteLine($"Minimum {transportTypeName} value: {minValue:C}");
            Console.WriteLine($"Maximum {transportTypeName} value: {maxValue:C}");
        }
    }
}