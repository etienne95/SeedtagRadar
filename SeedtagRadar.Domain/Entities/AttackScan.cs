namespace SeedtagRadar.Domain.Entities
{
    public class AttackScan
    {
        public Point Coordinates { get; set; }
        public Enemy Enemies { get; set; }
        public int Allies { get; set; }
    }
}