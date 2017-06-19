using RandomGeneratorTesting.RandomGenerators.Implementations;

namespace RandomGeneratorTesting.RandomGenerators
{
    public class MiddleSquareWeyl : RandomGenerator
    {
        private ulong x;
        private ulong w;
        private ulong s = 0xb5ad4eceda1ce2a9;

        private static MiddleSquareWeyl singleton;

        public static MiddleSquareWeyl Singleton
        {
            get { return singleton ?? (singleton = new MiddleSquareWeyl()); }
        }

        protected MiddleSquareWeyl() { }


        public override void Seed(ulong seed)
        {
            s = MiddleSquareWeylSeeds.Seeds[seed % (ulong)MiddleSquareWeylSeeds.Seeds.Length];
        }

        public override ulong GenerateUlong()
        {
            x *= x;
            x += w += s;
            return x = (x >> 32) | (x << 32);
        }

        public override float GenerateFloat()
        {
            return GenerateUlong() / ((float)ulong.MaxValue + 1);
        }

        public override string Name { get; } = "Middle square weyl generator";
    }
}
