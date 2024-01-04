using System;
using System.Windows;

namespace RandomFactory.Models
{

    public class RandomGenerator
    {
        private Random random = new Random();
        public bool UseRange { get; set; }
        public double MinRange { get; set; }
        public double MaxRange{ get; set; }

        public double GenerateDouble() {
            if (UseRange)
            {
                if (RangeException()) return 0;

                return MinRange + random.NextDouble() * (MaxRange - MinRange);
            }
            return random.NextDouble() * random.Next(); 
        }
        public int GenerateInt() {
            if (UseRange)
            {
                if (RangeException()) return 0;

                return (int)(MinRange + random.Next() % (MaxRange + 1 - MinRange));
            }
            return random.Next(); 
        }
        public int GeneratePercent() {
            if (PercentException()) return -1;
            if (RangeException()) return -1;

            if (UseRange) return GenerateInt();
            return random.Next() % 101; 
        }

        private bool RangeException()
        {
            if (MinRange > MaxRange)
            {
                MessageBox.Show("Минимальное значение должно быть не больше максимального");
                return true;
            }
            return false;
        }

        private bool PercentException()
        {
            if (MinRange < 0 || MinRange > 100 || MaxRange < 0 || MaxRange > 100)
            {
                MessageBox.Show("Проценты должны быть от 0 до 100");
                return true;
            }
            return false;
        }

    }
}
