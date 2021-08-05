using SeedtagRadar.Domain.Entities;

namespace SeedtagRadar.Domain.Interfaces
{
    public interface IScanService
    {
        Point GetTargetPoint(AttackInstruction instruction);
    }
}