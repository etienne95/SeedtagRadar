using System;

namespace SeedtagRadar.Domain.Entities
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Distance => Math.Sqrt(Math.Pow(Math.Abs(0 - X), 2) + Math.Pow(Math.Abs(0 - Y), 2));
    }
}