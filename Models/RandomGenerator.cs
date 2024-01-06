using System;
using System.Windows;

namespace RandomFactory.Models
{
    public class RandomGenerator
    {
        private Random random;

        private int seed;
        public int Seed
        {
            get => seed;
            set
            {
                seed = value;
                random = new Random(seed);
            }
        }

        public RandomGenerator() 
        {
            seed = Environment.TickCount;
            random = new Random(seed);
        }

        public int GenerateInt()
        {
            return random.Next();
        }
        public int GenerateInt(double minRange, double maxRange)
        {
            if (RangeException(minRange, maxRange)) return 0;

            return (int)(minRange + random.Next() % (maxRange + 1 - minRange));
        }

        public double GenerateDouble() {
            return random.NextDouble() * random.Next(); 
        }
        public double GenerateDouble(double minRange, double maxRange) {
            if (RangeException(minRange, maxRange)) return 0;

            return minRange + random.NextDouble() * (maxRange - minRange);
        }

        public int GeneratePercent() {
            return random.Next() % 101; 
        }
        public int GeneratePercent(double minRange, double maxRange) {
            if (PercentException(minRange, maxRange)) return -1;
            if (RangeException(minRange, maxRange)) return -1;

            return GenerateInt(minRange,maxRange);
        }

        private bool RangeException(double minRange, double maxRange)
        {
            if (minRange > maxRange)
            {
                MessageBox.Show("Минимальное значение должно быть не больше максимального");
                return true;
            }
            return false;
        }

        private bool PercentException(double minRange, double maxRange)
        {
            if (minRange < 0 || minRange > 100 || maxRange < 0 || maxRange > 100)
            {
                MessageBox.Show("Проценты должны быть от 0 до 100");
                return true;
            }
            return false;
        }


    }
}
