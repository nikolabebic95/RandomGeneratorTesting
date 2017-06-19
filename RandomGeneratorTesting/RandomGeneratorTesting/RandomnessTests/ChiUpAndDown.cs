using System.Collections.Generic;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class ChiUpAndDown : ChiSquareTest
    {
        private static ChiUpAndDown singleton;

        public static ChiUpAndDown Singleton
        {
            get { return singleton ?? (singleton = new ChiUpAndDown()); }
        }

        protected ChiUpAndDown() { }

        public override string Name { get; } = "Chi-Square up and down runs test";

        protected override ulong GetL(ulong size)
        {
            return size - 1;
        }

        protected override ulong CountRuns(IList<float> numbers, ulong length)
        {
            var up = numbers[1] < numbers[0];
            var curr = 0UL;
            var ret = 0UL;
            
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    if (up)
                    {
                        up = false;
                        if (curr == length)
                        {
                            ret++;
                        }

                        curr = 2;
                    }
                    else
                    {
                        curr++;
                    }
                }
                else
                {
                    if (!up)
                    {
                        up = true;
                        if (curr == length)
                        {
                            ret++;
                        }

                        curr = 2;
                    }
                    else
                    {
                        curr++;
                    }
                }
            }

            return ret;
        }

        protected override decimal ExpectedRuns(ulong above, ulong below, ulong length)
        {
            var n = above + below;
            if (length == n - 1)
            {
                return 2m / MathHelper.Factorial(n);
            }

            var fact = MathHelper.Factorial(length + 3);

            if (fact == 0) return decimal.MaxValue;
            fact = 2m / fact;

            var rest = n * (length * length + 3m * length + 1m) -
                        (length * length * length + 3 * length * length - length - 4m);

            return fact * rest;
        }
    }
}
