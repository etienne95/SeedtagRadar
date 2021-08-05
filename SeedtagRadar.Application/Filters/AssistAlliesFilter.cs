using System;
using System.Linq.Expressions;
using SeedtagRadar.Domain.Entities;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Application.Filters
{
    public class AssistAlliesFilter : IProtocolFilter
    {
        public Expression<Func<AttackScan, bool>> GetPredicate() => (AttackScan scan) => scan.Allies > 0;
    }
}