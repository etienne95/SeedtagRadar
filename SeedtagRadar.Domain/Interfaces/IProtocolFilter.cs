using System;
using System.Linq.Expressions;
using SeedtagRadar.Domain.Entities;

namespace SeedtagRadar.Domain.Interfaces
{
    public interface IProtocolFilter : IProtocol
    {
        Expression<Func<AttackScan, bool>> GetPredicate();
    }
}