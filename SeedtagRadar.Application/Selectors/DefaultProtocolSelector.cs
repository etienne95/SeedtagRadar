using System.Collections.Generic;
using System.Linq;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Selectors
{
    public class DefaultProtocolSelector : IProtocolSelector
    {
        public AttackScan SelectOne(IEnumerable<AttackScan> scans)
        {
            return scans.FirstOrDefault();
        }
    }
}