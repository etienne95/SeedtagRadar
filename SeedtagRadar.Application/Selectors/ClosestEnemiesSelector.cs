using System.Collections.Generic;
using System.Linq;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Selectors
{
    public class ClosestEnemiesSelector : IProtocolSelector
    {
        public AttackScan SelectOne(IEnumerable<AttackScan> scans)
        {
            return scans.OrderBy(s => s.Coordinates.Distance).FirstOrDefault();
        }
    }
}