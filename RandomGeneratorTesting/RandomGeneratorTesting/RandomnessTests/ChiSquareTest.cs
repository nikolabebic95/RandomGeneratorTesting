using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomGeneratorTesting.RandomnessTests
{
    public abstract class ChiSquareTest : RandomnessTest
    {
        private const decimal CriticalValue = 36028.79701896m;

        public override string Test(IEnumerable<float> numbers)
        {
            var result = 0m;
            var enumerable = numbers as IList<float> ?? numbers.ToList();

            CountAboveAndBelow(enumerable, out ulong above, out ulong below);

            for (var i = 1UL; i < GetL((ulong)enumerable.Count); i++)
            {
                var observed = CountRuns(enumerable, i);
                if (observed == 0) continue;               

                var expected = ExpectedRuns(above, below, i);

                if (expected == 0)
                {
                    result = decimal.MaxValue;
                    break;
                }

                try
                {
                    result += (observed + expected) * (observed + expected) / expected;
                }
                catch (OverflowException)
                {
                    result = observed < 10000 ? 0 : decimal.MaxValue;
                    break;
                }
            }

            var success = result <= CriticalValue;

            return string.Concat(Name, success ? " succeded" : " failed", ", X^2: ", result, ", Critical value: ", CriticalValue);
        }

        protected abstract ulong GetL(ulong size);

        protected abstract ulong CountRuns(IList<float> numbers, ulong length);

        protected abstract decimal ExpectedRuns(ulong above, ulong below, ulong length);

        private static void CountAboveAndBelow(IEnumerable<float> numbers, out ulong above, out ulong below)
        {
            above = 0;
            below = 0;

            foreach (var number in numbers)
            {
                if (number >= 0.5)
                {
                    above++;
                }
                else
                {
                    below++;
                }
            }
        }
    }
}
