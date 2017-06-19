using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGeneratorTesting.RandomnessTests
{
    public abstract class RandomnessTest
    {
        public static IDictionary<string, RandomnessTest> Dictionary = new Dictionary<string, RandomnessTest>();

        public static void InitializeDictionary()
        {
            Add(RunsAboveAndBelow.Singleton);
            Add(RunsUpAndDown.Singleton);
            Add(AutoCorrelationTest.Singleton);
            Add(KolmogorovSmirnov.Singleton);
            Add(ChiAboveAndBelow.Singleton);
            Add(ChiUpAndDown.Singleton);
        }

        private static void Add(RandomnessTest test)
        {
            Dictionary.Add(test.Name, test);
        }

        public abstract string Test(IEnumerable<float> numbers);

        public abstract string Name { get; }
    }
}
