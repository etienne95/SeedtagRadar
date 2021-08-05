namespace SeedtagRadar.Domain.Interfaces
{
    public interface IProtocolFactory
    {
        IProtocol GetProtocol(string protocolName);
    }
}