namespace TransportApp.Transport
{
    public interface IVehicle
    {
        // Interfaces information from: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
        VehicleType Type { get; set; }
        VehicleDimensions Dimensions { get; set; }
        float Weight { get; set; }
        FuelOptions FuelType { get; set; }
        DateTime PurchaseDate { get; set; }
        decimal Value { get; set; }
    }
}