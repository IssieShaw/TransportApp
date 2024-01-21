using TransportApp.CsvHandler;
using TransportApp.DataGenerator;
using TransportApp.Transport;

class Program
{
    static void Main()
    {
        // Build configuration
        var appConfig = ConfigurationBuilder.BuildConfiguration();
        CsvHandler.Init(appConfig);

        Console.WriteLine("Generating lists of transport vehicles:");
        List<Boat> boats = VehicleGenerator.GenerateRandomBoats(5);
        List<Car> cars = VehicleGenerator.GenerateRandomCars(6);
        List<Van> vans = VehicleGenerator.GenerateRandomVans(7);

        Console.WriteLine("\nWriting data to CSVs:");
        CsvHandler.WriteToCsv(boats, "boats.csv");
        CsvHandler.WriteToCsv(cars, "cars.csv");
        CsvHandler.WriteToCsv(vans, "vans.csv");

        Console.WriteLine("\nCalculating sums and value of company transport:");
        TransportCalculator.CalculateAndDisplayTotals(boats, cars, vans);

        Console.WriteLine("\nCaluclating Minimum and Maximum values from each list:");
        TransportCalculator.MinMaxValues(boats, cars, vans);
    }
}