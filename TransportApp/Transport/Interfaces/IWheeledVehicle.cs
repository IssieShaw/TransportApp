namespace TransportApp.Transport
{
    public interface IWheeledVehicle : IVehicle
    {
        int NumberOfDoors { get; set; }
    }
}