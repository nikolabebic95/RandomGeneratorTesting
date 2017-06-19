using System;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class LinearCongruentialGenerator : RandomGenerator
    {
        private const ulong A = 6364136223846793005;
        private const ulong C = 1442695040888963407;
        private ulong last = (ulong)DateTime.Now.Ticks;

        private static LinearCongruentialGenerator singleton;

        public static LinearCongruentialGenerator Singleton
        {
            get { return singleton ?? (singleton = new LinearCongruentialGenerator()); }
        }

        protected LinearCongruentialGenerator() { }

        public override void Seed(ulong seed)
        {
            last = seed;
        }

        public override ulong GenerateUlong()
        {
            last = A * last + C;
            return last;
       }

        public override float GenerateFloat()
        {
            return GenerateUlong() / ((float)ulong.MaxValue + 1);
        }

        public override string Name { get; } = "Linear Congruential Generator";
    }
}
