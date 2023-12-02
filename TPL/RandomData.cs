using System;

namespace TPL
{
    public static class RandomData
    {
        static Random rand = new Random();

        public static int GetIntNumber(int range) => rand.Next(0 - range/2, 0 + range / 2);
        public static double GetDoubleNumber(int range) => rand.Next(0 - range*100 / 2, 0 + range*100 / 2)/100.00;
    }
}
