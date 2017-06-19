using System;
using System.Collections.Generic;
using System.Linq;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public abstract class RunsTest : RandomnessTest
    {
        private const decimal CriticalValue = 1.96m;

        public override string Test(IEnumerable<float> numbers)
        {
            var enumerable = numbers as IList<float> ?? numbers.ToList();
            CountAboveAndBelow(enumerable, out ulong above, out ulong below);
            var runs = CountRuns(enumerable);
            var expected = ExpectedRuns(above, below);
            var deviation = StandardDeviation(above, below);

            var test = deviation != 0 ? (runs - expected) / deviation : decimal.MaxValue;

            var success = Math.Abs(test) <= CriticalValue;
            return string.Concat(Name, success ? " succeeded" : " failed", ", Z0: ", test, ", Critical value: ", CriticalValue);
        }

        protected abstract ulong CountRuns(IEnumerable<float> numbers);

        protected abstract decimal ExpectedRuns(ulong above, ulong below);

        protected abstract decimal StandardDeviation(ulong above, ulong below);
        

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
