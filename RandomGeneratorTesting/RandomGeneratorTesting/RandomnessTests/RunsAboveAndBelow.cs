using System.Collections.Generic;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class RunsAboveAndBelow : RunsTest
    {
        private static RunsAboveAndBelow singleton;

        public static RunsAboveAndBelow Singleton
        {
            get { return singleton ?? (singleton = new RunsAboveAndBelow()); }
        }

        protected RunsAboveAndBelow() { }
        
        public override string Name { get; } = "Test above and below median runs";

        protected override ulong CountRuns(IEnumerable<float> numbers)
        {
            var runs = 0UL;
            var isAbove = false;
            var first = true;

            foreach (var number in numbers)
            {
                if (number >= 0.5)
                {
                    if (!isAbove)
                    {
                        runs++;
                        isAbove = true;
                    }
                }
                else
                {
                    if (isAbove || first)
                    {
                        runs++;
                        isAbove = false;
                    }
                }

                first = false;
            }

            return runs;
        }

        protected override decimal ExpectedRuns(ulong above, ulong below)

        {
            var decimalAbove = (decimal)above;
            var decimalBelow = (decimal)below;
            return 2 * decimalAbove * decimalBelow / (decimalAbove + decimalBelow) + 0.5m;
        }

        protected override decimal StandardDeviation(ulong above, ulong below)
        {
            var decimalAbove = (decimal)above;
            var decimalBelow = (decimal)below;

            var up = 2 * decimalAbove * decimalBelow * (2 * decimalAbove * decimalBelow - decimalAbove - decimalBelow);
            var down = (decimalAbove + decimalBelow) * (decimalAbove + decimalBelow) *
                       (decimalAbove + decimalBelow - 1);

            if (up == 0) return 0;
            return down == 0 ? decimal.MaxValue : MathHelper.Sqrt(up / down);
        }
    }
}
