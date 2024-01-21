namespace TransportApp.Transport
{

    public class Van : Vehicle, IWheeledVehicle
    {
        public int NumberOfDoors { get; set; }

        public Van(VehicleType type,
                   VehicleDimensions dimensions,
                   float weight,
                   FuelOptions fuelType,
                   DateTime purchaseDate,
                   decimal value,
                   int numberOfDoors)
        {
            Type = type;
            Dimensions = dimensions;
            Weight = weight;
            FuelType = fuelType;
            PurchaseDate = purchaseDate;
            Value = value;
            NumberOfDoors = numberOfDoors;
        }
    }
}