using System;

namespace RandomFactory.Models
{

    public class RandomGenerator
    {
        private Random random = new Random();
        public double GenerateDouble() { return random.NextDouble(); }
        public int GenerateInt() { return random.Next(); }
        public int GeneratePercent() { return (int)(random.NextDouble() * 100); }

    }
}
