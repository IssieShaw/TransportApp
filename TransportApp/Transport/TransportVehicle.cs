using System.Diagnostics.CodeAnalysis;

namespace TransportApp.Transport
{
    public enum VehicleType
    {
        Boat,
        Car,
        Van
    }

    public enum FuelOptions
    {
        Petrol,
        Diesel,
        LPG,
        Biofuels,
        Electric,
        Hybrid
    }

    public class VehicleDimensions
    {
        public float LengthMM { get; set; }
        public float WidthMM { get; set; }
        public float HeightMM { get; set; }
    }

    public class Vehicle : IVehicle
    {
        private VehicleDimensions _dimensions = null!;
        public VehicleType Type { get; set; }
        // MemberNotNull from:  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis#helper-methods-membernotnull-and-membernotnullwhen
        public VehicleDimensions Dimensions
        {
            get => _dimensions;

            [MemberNotNull(nameof(_dimensions))]
            set => _dimensions = value ?? throw new ArgumentNullException(nameof(Dimensions), "Dimensions required.");
        }
        public float Weight { get; set; }
        public FuelOptions FuelType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
    }
}