using System.Collections.Generic;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class ChiAboveAndBelow : ChiSquareTest
    {
        private static ChiAboveAndBelow singleton;

        public static ChiAboveAndBelow Singleton
        {
            get { return singleton ?? (singleton = new ChiAboveAndBelow()); }
        }

        protected ChiAboveAndBelow() { }

        public override string Name { get; } = "Chi-Square above and below runs test";
        protected override ulong GetL(ulong size)
        {
            return size;
        }

        protected override ulong CountRuns(IList<float> numbers, ulong length)
        {
            var curr = 0UL;
            var isAbove = numbers[0] < 0.5;
            var ret = 0UL;

            foreach (var number in numbers)
            {
                if (number >= 0.5)
                {
                    if (!isAbove)
                    {
                        isAbove = true;
                        if (curr == length)
                        {
                            ret++;
                        }

                        curr = 1;
                    }
                    else
                    {
                        curr++;
                    }
                }
                else
                {
                    if (isAbove)
                    {
                        isAbove = false;
                        if (curr == length)
                        {
                            ret++;
                        }

                        curr = 1;
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
            var decimalAbove = (decimal) above;
            var decimalBelow = (decimal) below;

            var e = decimalAbove / decimalBelow + decimalBelow / decimalAbove;

            return (above + below) * Weight(above, below, length) / e;
        }

        private static decimal Weight(ulong above, ulong below, ulong i)
        {
            var n = (decimal)(above + below);
            var first = MathHelper.Pow(above / n, i);
            var second = below / n;
            var third = above / n;
            var fourth = MathHelper.Pow(below / n, i);

            return first * second + third * fourth;
        }
    }
}
