using System;
using System.Linq.Expressions;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Filters
{
    public class AvoidCrossfireFilter : IProtocolFilter
    {
        public Expression<Func<AttackScan, bool>> GetPredicate() => (AttackScan scan) => scan.Allies == 0;
    }
}