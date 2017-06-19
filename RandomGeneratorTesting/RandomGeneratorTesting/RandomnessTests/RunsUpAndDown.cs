using System.Collections.Generic;
using System.Linq;
using RandomGeneratorTesting.Helpers;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class RunsUpAndDown : RunsTest
    {
        private static RunsUpAndDown singleton;

        public static RunsUpAndDown Singleton
        {
            get { return singleton ?? (singleton = new RunsUpAndDown()); }
        }

        protected RunsUpAndDown() { }        

        protected override ulong CountRuns(IEnumerable<float> numbers)
        {            
            var up = false;
            var runs = 0UL;

            var enumerable = numbers as IList<float> ?? numbers.ToList();
            for (var i = 1; i < enumerable.Count; i++)
            {
                if (enumerable[i] < enumerable[i - 1])
                {
                    if (up)
                    {
                        runs++;
                        up = false;
                    }
                }
                else
                {
                    if (!up || i == 0)
                    {
                        runs++;
                        up = true;
                    }
                }
            }

            return runs;
        }

        protected override decimal ExpectedRuns(ulong above, ulong below)
        {
            return (2m * (above + below) - 1m) / 3m;
        }

        protected override decimal StandardDeviation(ulong above, ulong below)
        {
            return MathHelper.Sqrt((16m * (above + below) - 29m) / 90m);
        }

        public override string Name { get; } = "Runs up and down test";
    }
}
