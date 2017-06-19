using System;
using System.Collections.Generic;
using System.Linq;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class AutoCorrelationTest : RandomnessTest
    {
        private const decimal CriticalValue = 1.96m;

        private static AutoCorrelationTest singleton;

        public static AutoCorrelationTest Singleton
        {
            get { return singleton ?? (singleton = new AutoCorrelationTest()); }
        }

        protected AutoCorrelationTest() { }

        public override string Test(IEnumerable<float> numbers)
        {
            var enumerable = numbers as IList<float> ?? numbers.ToList();

            var correlation = Correlation(enumerable);
            var deviation = Deviation((uint)enumerable.Count);

            var test = correlation / deviation;

            var success = Math.Abs(test) <= CriticalValue;

            return string.Concat(Name, success ? " succeded" : " failed", ", Z0: ", test, ", Critical value: ", CriticalValue);
        }

        private static decimal Correlation(IList<float> numbers)
        {
            var sum = 0m;
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                sum += (decimal)numbers[i] * (decimal)numbers[i + 1];
            }

            return 1m / numbers.Count * sum - 0.25m;
        }

        private static decimal Deviation(uint size)
        {
            var up = MathHelper.Sqrt(13m * size - 6);
            var down = 12m * size;
            return up / down;
        }

        public override string Name { get; } = "Auto-correlation test";
    }
}
