using SeedtagRadar.Application.Filters;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;
using SeedtagRadar.Application.Helpers;
using System.Linq;
using SeedtagRadar.Application.Selectors;

namespace SeedtagRadar.Application.Services
{
    public class ScanService : IScanService
    {
        private readonly IProtocolFactory _protocolFactory;

        public ScanService(IProtocolFactory protocolFactory)
        {
            _protocolFactory = protocolFactory;
        }

        public Point GetTargetPoint(AttackInstruction instruction)
        {
            var defaultPredicate = new DefaultProtocolFilter().GetPredicate();
            IProtocolSelector selector = new DefaultProtocolSelector();

            foreach (var protocolName in instruction.Protocols)
            {
                var protocol = _protocolFactory.GetProtocol(protocolName);

                if (protocol is IProtocolFilter)
                {
                    defaultPredicate = defaultPredicate.And<AttackScan>(((IProtocolFilter)protocol).GetPredicate());
                }
                else
                {
                    selector = (IProtocolSelector)protocol;
                }
            }
            return selector.SelectOne(instruction.Scan.Where(defaultPredicate.Compile())).Coordinates;
        }
    }
}