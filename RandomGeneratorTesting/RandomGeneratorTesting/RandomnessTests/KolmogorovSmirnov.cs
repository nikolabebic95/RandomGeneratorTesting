using System.Collections.Generic;
using System.Linq;

namespace RandomGeneratorTesting.RandomnessTests
{
    public class KolmogorovSmirnov : RandomnessTest
    {
        private const decimal CriticalValue = 0.04301m;

        private static KolmogorovSmirnov singleton;

        public static KolmogorovSmirnov Singleton
        {
            get { return singleton ?? (singleton = new KolmogorovSmirnov()); }
        }

        protected KolmogorovSmirnov() { }

        public override string Test(IEnumerable<float> numbers)
        {
            var list = numbers.ToList();
            list.Sort();

            var max = 0m;
            var min = 0m;

            for (var i = 0; i < list.Count; i++)
            {
                var up = (i + 1m) / list.Count - (decimal)list[i];
                var down = (decimal) list[i] - (i + 0m) / list.Count;
                if (up > max) max = up;
                if (down > min) min = down;
            }

            var diff = max > min ? max : min;

            var success = diff <= CriticalValue;

            return string.Concat(Name, success ? " succeeded" : " failed", ", D: ", diff, ", Critical value: ",
                CriticalValue);
        }



        public override string Name { get; } = "Kolmogorov-Smirnov test";
    }
}
