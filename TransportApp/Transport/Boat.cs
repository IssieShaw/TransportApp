namespace TransportApp.Transport
{
    public class Boat : Vehicle, IFloatingVehicle
    {
        public double KeelDepth { get; set; }

        public Boat(VehicleType type,
                    VehicleDimensions dimensions,
                    float weight,
                    FuelOptions fuelType,
                    DateTime purchaseDate,
                    decimal value,
                    double keepDepth)
        {
            Type = type;
            Dimensions = dimensions;
            Weight = weight;
            FuelType = fuelType;
            PurchaseDate = purchaseDate;
            Value = value;
            KeelDepth = keepDepth;
        }
    }
}