using System.Collections.Generic;
using SeedtagRadar.Domain.Entities;

namespace SeedtagRadar.Domain.Interfaces
{
    public interface IProtocolSelector : IProtocol
    {
        AttackScan SelectOne(IEnumerable<AttackScan> scans);
    }
}