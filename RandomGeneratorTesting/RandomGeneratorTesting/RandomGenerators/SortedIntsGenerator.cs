using System;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class SortedIntsGenerator : RandomGenerator
    {
        private ulong curr = (ulong)DateTime.Now.Ticks;

        private static SortedIntsGenerator singleton;

        public static SortedIntsGenerator Singleton
        {
            get { return singleton ?? (singleton = new SortedIntsGenerator()); }
        }

        protected SortedIntsGenerator() { }

        public override void Seed(ulong seed)
        {
            curr = (uint) seed;
        }

        public override ulong GenerateUlong()
        {
            return curr += ulong.MaxValue / 1024;
        }

        public override float GenerateFloat()
        {
            return GenerateUlong() / ((float) ulong.MaxValue + 1);
        }

        public override string Name { get; } = "Sorted data generator";
    }
}
