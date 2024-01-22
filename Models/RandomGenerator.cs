using System;
using System.Windows;

namespace RandomFactory.Models
{
    public class RandomGenerator
    {
        private Random random;

        public RandomGenerator() 
        {
            random = new Random(seed);
        }

        private bool exception = false;
        public bool Exception
        {
            get { return exception; }
        }

        private int seed = Environment.TickCount;
        public int Seed
        {
            get => seed;
        }

        private int step = 0;
        public int Step
        {
            get { return step; }
        }

        public void SetSeed(int value, int _step = 0)
        {
            seed = value;
            random = new Random(value);
            for (step = 0; step < _step;)
            {
                GenerateInt();
            }
        }

        public int GenerateInt()
        {
            step++;
            return random.Next();
        }
        public int GenerateInt(double minRange, double maxRange)
        {
            if (RangeException(minRange, maxRange)) return 0;

            step++;
            return (int)(minRange + random.Next() % (maxRange + 1 - minRange));
        }

        public double GenerateDouble()
        {
            step++;
            return random.NextDouble() * random.Next(); 
        }
        public double GenerateDouble(double minRange, double maxRange)
        {
            if (RangeException(minRange, maxRange)) return 0;

            step++;
            return minRange + random.NextDouble() * (maxRange - minRange);
        }

        public int GeneratePercent()
        {
            step++;
            return random.Next() % 101; 
        }
        public int GeneratePercent(double minRange, double maxRange)
        {
            if (PercentException(minRange, maxRange)) return -1;
            if (RangeException(minRange, maxRange)) return -1;

            return GenerateInt(minRange, maxRange);
        }

        private bool RangeException(double minRange, double maxRange)
        {
            if (minRange > maxRange)
            {
                MessageBox.Show("Минимальное значение должно быть не больше максимального");
                exception = true;
            }
            else exception = false;
            return exception;
        }

        private bool PercentException(double minRange, double maxRange)
        {
            if (minRange < 0 || minRange > 100 || maxRange < 0 || maxRange > 100)
            {
                MessageBox.Show("Проценты должны быть от 0 до 100");
                exception = true;
            }
            else exception = false;
            return exception;
        }


    }
}
