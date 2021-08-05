using Autofac;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Services
{
    public class ProtocolFactory : IProtocolFactory
    {
        private readonly IComponentContext _container;

        public ProtocolFactory(IComponentContext container)
        {
            _container = container;
        }

        public IProtocol GetProtocol(string protocolName) => _container.ResolveNamed<IProtocol>(protocolName);
    }
}