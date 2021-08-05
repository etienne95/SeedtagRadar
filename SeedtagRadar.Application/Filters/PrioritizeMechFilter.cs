using System;
using System.Linq.Expressions;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Filters
{
    public class PrioritizeMechFilter : IProtocolFilter
    {
        public Expression<Func<AttackScan, bool>> GetPredicate()
            => (AttackScan scan) => scan.Enemies.Type == "mech" && scan.Enemies.Number > 0;
    }
}