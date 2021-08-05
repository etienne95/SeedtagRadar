using System;
using System.Linq.Expressions;
using SeedtagRadar.Domain;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Filters
{
    public class DefaultProtocolFilter : IProtocolFilter
    {
        public Expression<Func<AttackScan, bool>> GetPredicate() =>
            (AttackScan scan) => scan.Coordinates.Distance <= Constants.DISTANCE_LIMIT;
    }
}