using TransportApp.Transport;


namespace TransportApp.DataGenerator
{
    public static class VehicleGenerator
    {
        private static readonly Random random = new Random();

        public static List<Boat> GenerateRandomBoats(int count)
        {
            List<Boat> boats = new List<Boat>();

            for (int i = 0; i < count; i++)
            {
                boats.Add(new Boat(
                    VehicleType.Boat,
                    GetRandomVehicleDimensions(),
                    GetRandomWeight(),
                    GetRandomFuelType(),
                    GetRandomPurchaseDate(),
                    GetRandomValue(),
                    GetRandomKeelDepth()
                ));
            }
            Console.WriteLine($"Generated list including {count} {VehicleType.Boat}(s).");
            return boats;
        }

        public static List<Car> GenerateRandomCars(int count)
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                cars.Add(new Car(
                    VehicleType.Car,
                    GetRandomVehicleDimensions(),
                    GetRandomWeight(),
                    GetRandomFuelType(),
                    GetRandomPurchaseDate(),
                    GetRandomValue(),
                    GetRandomNumberOfDoors()
                ));
            }
            Console.WriteLine($"Generated list including {count} {VehicleType.Car}(s).");
            return cars;
        }

        public static List<Van> GenerateRandomVans(int count)
        {
            List<Van> vans = new List<Van>();

            for (int i = 0; i < count; i++)
            {
                vans.Add(new Van(
                    VehicleType.Van,
                    GetRandomVehicleDimensions(),
                    GetRandomWeight(),
                    GetRandomFuelType(),
                    GetRandomPurchaseDate(),
                    GetRandomValue(),
                    GetRandomNumberOfDoors()
                ));
            }
            Console.WriteLine($"Generated list including {count} {VehicleType.Van}(s).");
            return vans;
        }

        private static VehicleDimensions GetRandomVehicleDimensions()
        {
            return new VehicleDimensions
            {
                LengthMM = (float)(random.NextDouble() * 6000 + 3000),
                WidthMM = (float)(random.NextDouble() * 2000 + 1000),
                HeightMM = (float)(random.NextDouble() * 2500 + 1000)
            };
        }

        private static float GetRandomWeight()
        {
            return (float)(random.NextDouble() * 2000 + 1500);
        }

        private static FuelOptions GetRandomFuelType()
        {
            FuelOptions[] values = (FuelOptions[])Enum.GetValues(typeof(FuelOptions));
            return values[random.Next(values.Length)];
        }

        private static DateTime GetRandomPurchaseDate()
        {
            int daysAgo = random.Next(365 * 5);
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }

        private static decimal GetRandomValue()
        {
            return (decimal)(random.NextDouble() * 100000 + 5000);
        }

        private static int GetRandomNumberOfDoors()
        {
            return random.Next(2, 7);
        }

        private static double GetRandomKeelDepth()
        {
            return random.NextDouble() * 5 + 0.5;
        }
    }
}