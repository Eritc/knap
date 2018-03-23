using System;

namespace bitflyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fee = { 0887, 1856, 2307, 1522, 0532, 0250, 1409, 2541, 1147, 2660, 2933, 0686 };
            int[] size = { 57247, 98732, 134928, 77275, 29240, 15440, 70820, 139603, 63718, 143807, 190457, 40572 };
            int capacity = 1000000;
            int itemsCount = 12;

            int result = Block(capacity, size, fee, itemsCount);
            double btc = result / 10000 + 12.5;
            Console.WriteLine(btc);
            Console.Read();
        }

        public static int Block(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }
            return K[itemsCount, capacity];
        }
    }
}
