using System.Collections.Generic;

namespace SeedtagRadar.Domain.Entities
{
    public class AttackInstruction
    {
        public IEnumerable<string> Protocols { get; set; }
        public IEnumerable<AttackScan> Scan { get; set; }
    }
}